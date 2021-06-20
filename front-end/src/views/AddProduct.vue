<template>
  <div class="mb-4 mx-0 w-full">
    <div class="shadow-lg rounded-2xl bg-white dark:bg-gray-700 w-full">
      <p class="font-bold text-md p-4 text-black dark:text-white">
        Add Product
      </p>

      <div class="mx-8">
        <form action="" class="mt-6">
          <div class="my-5 text-sm">
            <input
              type="text"
              autofocus
              class="
                rounded-sm
                px-4
                py-3
                mt-3
                focus:outline-none
                bg-gray-100
                w-full
              "
              placeholder="Product Name"
              v-model="name"
            />
          </div>
          <div class="my-5 text-sm">
            <input
              type="text"
              class="
                rounded-sm
                px-4
                py-3
                mt-3
                focus:outline-none
                bg-gray-100
                w-full
              "
              placeholder="Product Description"
              v-model="description"
            />
          </div>
          <div class="my-5 text-sm">
            <input
              type="number"
              class="
                rounded-sm
                px-4
                py-3
                mt-3
                focus:outline-none
                bg-gray-100
                w-full
              "
              placeholder="Unit Price"
              v-model="price"
            />
          </div>
          <div class="my-5 text-sm">
            <input
              type="number"
              class="
                rounded-sm
                px-4
                py-3
                mt-3
                focus:outline-none
                bg-gray-100
                w-full
              "
              placeholder="Units In Stock"
              v-model="stock"
            />
          </div>
        </form>
      </div>

      <div class="flex flex-col items-end">
        <div class="mb-8">
          <router-link
            to="/"
            class="
              bg-red-700
              mr-1
              px-5
              py-3
              text-sm
              shadow-sm
              font-medium
              tracking-wider
              border
              text-red-100
              rounded-full
              hover:shadow-lg hover:bg-red-800
            "
          >
            Cancel
          </router-link>
          <button
            class="
              bg-green-600
              mr-8
              px-5
              py-3
              text-sm
              shadow-sm
              font-medium
              tracking-wider
              border
              text-green-100
              rounded-full
              hover:shadow-lg hover:bg-green-700
            "
            v-on:click="addProduct"
          >
            Add
          </button>
        </div>
      </div>
    </div>

    <div
      v-if="error"
      class="shadow-lg rounded-2xl bg-white dark:bg-gray-700 w-full my-8 p-8"
    >
      <ul>
        <li v-for="error in errors" :key="error">
          {{ error }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import Product from "@/models/product";
import { Options, Vue } from "vue-class-component";

@Options({})
export default class AddProduct extends Vue {
  name = "";
  description = "";
  price = 0;
  stock = 0;

  error = false;
  errors: string[] = [];

  private product!: Product;

  addProduct(): void {
    this.product = {
      name: this.name,
      description: this.description,
      unitPrice: Number(this.price),
      unitsInStock: Number(this.stock),
      id: -1,
    };

    fetch("http://localhost:5000/products", {
      method: "POST",
      body: JSON.stringify(this.product),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((data) => {
        this.errors = [];
        if (!data.ok) {
          this.error = true;
          return data.json();
        } else {
          this.error = false;
          this.$router.push("/");
        }
      })
      .then((data) => {
        for (const error in data.errors) {
          if (Object.prototype.hasOwnProperty.call(data.errors, error)) {
            this.errors = this.errors.concat(data.errors[error]);
          }
        }
      });
  }
}
</script>
