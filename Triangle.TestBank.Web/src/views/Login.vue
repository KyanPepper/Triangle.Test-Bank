<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <v-card>
          <v-card-title>Login</v-card-title>
          <v-card-text>
            <v-form>
              <v-text-field
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
