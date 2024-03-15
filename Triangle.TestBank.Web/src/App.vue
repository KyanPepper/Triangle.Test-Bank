<template>
  <v-app id="vue-app">
    <v-app-bar color="primary" density="compact">
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>
        <router-link to="/" style="color: inherit">
          Coalesce Vue Template
        </router-link>
      </v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer">
      <v-list>
        <v-list-item to="/" prepend-icon="fas fa-home" title="Home" />
        <v-list-item
          to="/widget"
          prepend-icon="fas fa-palette"
          title="Custom Page Example"
        />
        <v-list-item
          to="/admin"
          prepend-icon="fas fa-cogs"
          title="Admin Pages"
        />
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <!-- https://stackoverflow.com/questions/52847979/what-is-router-view-key-route-fullpath -->
      <router-view v-slot="{ Component, route }">
        <transition name="router-transition" mode="out-in" appear>
          <component :is="Component" :key="route.path" />
        </transition>
      </router-view>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
const drawer = ref<boolean | null>(null);
</script>

<style lang="scss">
.router-transition-enter-active,
.router-transition-leave-active {
  transition: 0.1s ease-out;
}

.router-transition-enter-from,
.router-transition-leave-to {
  opacity: 0;
}
</style>
