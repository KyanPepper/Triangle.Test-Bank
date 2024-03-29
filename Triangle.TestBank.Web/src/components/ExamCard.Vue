<template>
  <v-card class="flex">
    <div>
      <embed
        type="application/pdf"
        style="width: auto; height: auto"
        :src="
          'https://drive.google.com/viewerng/viewer?embedded=true&url=' + pdf
        "
      />
    </div>
    <v-card-title>
      <span class="text-h5">{{ name }}</span>
      <v-spacer></v-spacer>
    </v-card-title>

    <v-card-subtitle> {{ subject }}, {{ term }} </v-card-subtitle>

    <v-card-actions>
      <v-btn color="red-lighten-2" variant="text" @click="DownloadPdf">
        Download
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  props: {
    name: {
      type: String,
      required: true,
    },
    term: {
      type: String,
      required: true,
    },
    subject: {
      type: String,
      required: true,
    },
    pdf: {
      type: String,
      required: true,
    },
  },
  methods: {
    DownloadPdf() {
      const link = document.createElement("a");
      link.href = this.pdf;
      link.setAttribute("download", "");
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    },
  },
};
</script>
