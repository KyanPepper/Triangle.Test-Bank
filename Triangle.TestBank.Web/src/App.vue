<template>
  <v-app id="vue-app">
    <v-app-bar  color="red" density="compact">
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>
        <router-link to="/" style="color: inherit">
          WSU Triangle Fraternity Test Bank
        </router-link>
      </v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer">
      <v-list>
        <v-list-item to="/" prepend-icon="fa fa-calculator" title="Exams" />
        <v-list-item to="/uploadExam" prepend-icon="fa fa-cloud-upload" title="Upload Exam" />
        <v-list-item to="/login" prepend-icon="fa fa-sign-in-alt" title="Login" />
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

.navtri {
  color: red;
  align-self: center;
  justify-content: center;
}
</style>
