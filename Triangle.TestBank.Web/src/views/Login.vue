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
                placeholder="Password"
                type="password"
              ></v-text-field>
              <v-btn @click="login" color="red">Login</v-btn>
            </v-form>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { defineComponent } from "vue";
import { ExamServicesApiClient } from "@/api-clients.g";
const userInput = ref<string>("");
const login = async () => {
  const client = new ExamServicesApiClient();
  const response = await client.$makeCaller("item", (methods) =>
    methods.checkPassCode(userInput.value),
  );
  if (response.result == true) {
    console.log("Login Successful");
  } else {
    console.log("Login Failed");
  }
};
</script>
