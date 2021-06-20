<template>
  <main
    class="
      bg-gray-100
      dark:bg-gray-800
      rounded-2xl
      relative
      h-screen
      overflow-hidden
    "
  >
    <div class="flex items-start justify-between">
      <div class="flex flex-col w-full pl-0 md:p-4 md:space-y-4">
        <div
          class="
            overflow-auto
            h-screen
            pb-24
            pt-2
            pr-2
            pl-2
            md:pt-0 md:pr-0 md:pl-0
          "
        >
          <div class="flex flex-col flex-wrap sm:flex-row">
            <router-view />
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
