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
          <router-link
            to="/"
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
          >
            Add
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
