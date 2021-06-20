<template>
  <div>
    <header
      class="
        shadow-lg
        bg-white
        dark:bg-gray-700
        items-center
        h-16
        rounded-2xl
        z-40
        mb-4
        w-full
      "
    >
      <div
        class="
          relative
          z-20
          flex flex-col
          justify-center
          h-full
          px-3
          flex-center
        "
      >
        <div class="relative items-center pl-1 flex w-full">
          <input
            type="text"
            class="
              block
              py-1.5
              pl-4
              pr-4
              leading-normal
              rounded-2xl
              focus:border-transparent
              focus:outline-none
              focus:ring-2
              focus:ring-blue-500
              ring-opacity-90
              bg-gray-100
              dark:bg-gray-800
              text-gray-400
              aa-input
              w-full
            "
            placeholder="Search"
            v-model="filterString"
            @keyup="filterProducts"
          />
        </div>
      </div>
    </header>

    <div class="mb-4 mx-0 w-full">
      <div class="shadow-lg rounded-2xl bg-white dark:bg-gray-700 w-full">
        <p class="font-bold text-md p-4 text-black dark:text-white">Products</p>

        <!-- TABLE -->
        <table class="table-fixed w-full">
          <thead>
            <tr>
              <th class="w-1/4 ...">Name</th>
              <th class="w-1/4 ...">Description</th>
              <th class="w-1/4 ...">Unit Price</th>
              <th class="w-1/4 ...">Units In Stock</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="product in products" :key="product?.id">
              <td>{{ product.name }}</td>
              <td>{{ product.description }}</td>
              <td>{{ product.unitPrice }}</td>
              <td>{{ product.unitsInStock }}</td>
            </tr>
          </tbody>
        </table>

        <!-- PAGINATION -->
        <div>
          <nav class="relative z-0 inline-flex shadow-sm p-8">
            <div v-if="page > 1">
              <a
                href="#"
                class="
                  relative
                  inline-flex
                  items-center
                  px-2
                  py-2
                  rounded-l-md
                  border border-gray-300
                  bg-white
                  text-sm
                  leading-5
                  font-medium
                  text-gray-500
                  hover:text-gray-400
                  focus:z-10
                  focus:outline-none
                  focus:border-blue-300
                  focus:shadow-outline-blue
                  active:bg-gray-100 active:text-gray-500
                  transition
                  ease-in-out
                  duration-150
                "
                aria-label="Previous"
                v-on:click.prevent="changePage(page - 1)"
              >
                <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                  <path
                    fill-rule="evenodd"
                    d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z"
                    clip-rule="evenodd"
                  />
                </svg>
              </a>
            </div>
            <div>
              <a
                href="#"
                class="
                  -ml-px
                  relative
                  inline-flex
                  items-center
                  px-4
                  py-2
                  border border-gray-300
                  bg-white
                  text-sm
                  leading-5
                  font-medium
                  text-blue-700
                  focus:z-10
                  focus:outline-none
                  focus:border-blue-300
                  focus:shadow-outline-blue
                  active:bg-tertiary active:text-gray-700
                  transition
                  ease-in-out
                  duration-150
                  hover:bg-tertiary
                "
              >
                {{ page }}
              </a>
            </div>
            <div v-if="products.length == pageSize">
              <a
                href="#"
                class="
                  -ml-px
                  relative
                  inline-flex
                  items-center
                  px-2
                  py-2
                  rounded-r-md
                  border border-gray-300
                  bg-white
                  text-sm
                  leading-5
                  font-medium
                  text-gray-500
                  hover:text-gray-400
                  focus:z-10
                  focus:outline-none
                  focus:border-blue-300
                  focus:shadow-outline-blue
                  active:bg-gray-100 active:text-gray-500
                  transition
                  ease-in-out
                  duration-150
                "
                aria-label="Next"
                v-on:click.prevent="changePage(page + 1)"
              >
                <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                  <path
                    fill-rule="evenodd"
                    d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
                    clip-rule="evenodd"
                  />
                </svg>
              </a>
            </div>
          </nav>
        </div>

        <div class="flex flex-col items-end">
          <router-link
            to="/add-product"
            class="
              bg-green-600
              mb-8
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
          >
            Add Product
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Product from "@/models/product";
import { Options, Vue } from "vue-class-component";

@Options({
  props: {},
})
export default class ProductTable extends Vue {
  pageSize = 15;
  page = 1;
  products: Product[] = [];
  filterString = "";

  mounted(): void {
    this.$nextTick(this.fetchProducts);
  }

  changePage(newPage: number): void {
    if (newPage > 0) {
      this.page = newPage;
      this.fetchProducts();
    }
  }

  filterProducts(event: KeyboardEvent): void {
    this.page = 1;
    this.fetchProducts();
  }

  private fetchProducts(): void {
    fetch(
      `http://localhost:5000/products?PageSize=${this.pageSize}&Page=${this.page}&Filter=${this.filterString}`
    )
      .then((data) => {
        return data.json();
      })
      .then((data: Product[]) => {
        this.products = data;
      });
  }
}
</script>

<style scoped lang="scss"></style>
