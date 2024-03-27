<template>
    <v-container>
    <v-card class="flex flex-column justify-space-between">
      <div>
        embed pdf here
      </div>
      <v-card-title>
        <span class="text-h5">{{ name }}</span>
        <v-spacer></v-spacer>
      </v-card-title>

      <v-card-subtitle>
        Tags:{{ subject }}, {{ term }}
      </v-card-subtitle>

      <v-card-actions>
        <v-btn color="red-lighten-2" variant="text" @click="downloadPdf">
          Download
        </v-btn>

      </v-card-actions>

    </v-card>
  </v-container>
</template>


<script>
export default {
  props: {
    name: {
      type: String,
      required: true
    },
    term: {
      type: String,
      required: true
    },
    subject: {
      type: String,
      required: true
    },
    pdf: {
      type: String,
      required: true
    }
  },
  methods: {
    downloadPdf() {
      console.log("Download clicked");
    }
  }
};
</script>