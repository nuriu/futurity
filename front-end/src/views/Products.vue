<template>
  <div class="home">
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
  </div>
  <div class="mb-4 mx-0 w-full">
    <div class="shadow-lg rounded-2xl bg-white dark:bg-gray-700 w-full">
      <p class="font-bold text-md p-4 text-black dark:text-white">Products</p>
    </div>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src

@Options({
  components: {
    HelloWorld,
  },
})
export default class Products extends Vue {}
</script>
