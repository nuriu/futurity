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
      <div class="h-screen hidden lg:block my-4 ml-4 shadow-lg relative w-80">
        <div class="bg-white h-full rounded-2xl dark:bg-gray-700">
          <div class="flex items-center justify-center pt-6">
            <!-- logo -->
          </div>
          <nav class="mt-6">
            <div>
              <router-link
                to="/"
                class="
                  w-full
                  font-thin
                  uppercase
                  text-blue-500
                  flex
                  items-center
                  p-4
                  my-2
                  transition-colors
                  duration-200
                  justify-start
                  bg-gradient-to-r
                  from-white
                  to-blue-100
                  border-r-4 border-blue-500
                  dark:from-gray-700 dark:to-gray-800
                "
                href="#"
              >
                <span class="text-left">
                  <!-- icon -->
                </span>
                <span class="mx-4 text-sm font-normal"> Products </span>
              </router-link>
              <router-link
                to="/add-product"
                class="
                  w-full
                  font-thin
                  uppercase
                  text-gray-500
                  dark:text-gray-200
                  flex
                  items-center
                  p-4
                  my-2
                  transition-colors
                  duration-200
                  justify-start
                  hover:text-blue-500
                "
              >
                <span class="text-left">
                  <!-- icon -->
                </span>
                <span class="mx-4 text-sm font-normal"> Add Product </span>
              </router-link>
            </div>
          </nav>
        </div>
      </div>
      <div class="flex flex-col w-full pl-0 md:p-4 md:space-y-4">
        <header
          class="
            w-full
            shadow-lg
            bg-white
            dark:bg-gray-700
            items-center
            h-16
            rounded-2xl
            z-40
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
              mx-auto
              flex-center
            "
          >
            <div
              class="
                relative
                items-center
                pl-1
                flex
                w-full
                lg:max-w-68
                sm:pr-2 sm:ml-0
              "
            >
              <div class="container relative left-0 z-50 flex h-full">
                <div class="relative flex items-center w-full h-full group">
                  <div
                    class="
                      absolute
                      z-50
                      items-center
                      justify-center
                      block
                      w-auto
                      h-10
                      p-3
                      pr-2
                      text-sm text-gray-500
                      uppercase
                      cursor-pointer
                      sm:hidden
                    "
                  ></div>
                  <input
                    type="text"
                    class="
                      block
                      w-full
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
                    "
                    placeholder="Search"
                  />
                </div>
              </div>
            </div>
          </div>
        </header>
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
