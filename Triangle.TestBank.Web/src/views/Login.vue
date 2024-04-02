<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <v-card>
          <v-card-title>Login</v-card-title>
          <v-card-text>
            <v-form>
              <v-text-field
                v-model="userInput"
                label="Password"
                outlined
                clearable
                placeholder="Enter Password"
                type="password"
              ></v-text-field>
              <v-btn v-if="isLoggedIn !== 'true'" @click="Login" color="red"
                >Login</v-btn
              >
              <VAlert v-if="isLoggedIn == 'true'" type="success">
                Logged In Successfully
              </VAlert>
            </v-form>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ExamServicesApiClient } from "@/api-clients.g";
import { GetCookie } from "@/helperfunctions";

const userInput = ref<string>("");
let isLoggedIn = ref<string | null>("");

onMounted(() => {
  isLoggedIn.value = GetCookie("loggedIn");
});

let Login = async () => {
  const client = new ExamServicesApiClient();
  const response = await client.$makeCaller("item", (methods) =>
    methods.checkPassCode(userInput.value),
  );
  await response();
  if (response.result === true) {
    let expirationDate: Date = new Date();
    expirationDate.setTime(expirationDate.getTime() + 24 * 60 * 60 * 1000);
    document.cookie = `loggedIn=true; expires=${expirationDate.toUTCString()}; path=/`;
    isLoggedIn.value = "true";
  } else {
    alert("Incorrect Password");
  }
};
</script>
