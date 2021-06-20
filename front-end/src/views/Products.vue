<template>
  <div class="w-full">
    <ProductTable />
  </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import ProductTable from "@/components/ProductTable.vue"; // @ is an alias to /src

@Options({
  components: {
    ProductTable,
  },
})
export default class Products extends Vue {}
</script>
