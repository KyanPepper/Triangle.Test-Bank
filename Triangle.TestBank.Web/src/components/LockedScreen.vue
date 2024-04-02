<template>
      <div class="overlay-content">
        <VAlert type="error" > You Are Not Logged In </VAlert>
        <div class="center-text">
          <h1>Welcome to Our Website!</h1>
          <p>Please log in to access all features.</p>
          <router-link to="/login" class="login-button">Login</router-link>
        </div>
      </div>
  </template>
  
  <style scoped>

  .overlay-content {
    background-color: white;
    padding: 20px;
    border-radius: 5px;
  }
  
  .center-text {
    text-align: center;
  }
  


  </style>
<script lang="ts">
import { VAlert } from 'vuetify/lib/components/index.mjs';


</script>
