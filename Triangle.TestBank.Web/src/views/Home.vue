<template>
  <div>
    <v-card v-for="exam in examList" :key="exam.examId">
      <v-card-title>{{ exam.name }}</v-card-title>
      <v-card-text>{{ exam.pdfPath }}</v-card-text>
    </v-card>
    arqwe
  </div>
</template>

<script setup lang="ts">
import { ExamApiClient } from '@/api-clients.g';
import { Exam } from '@/models.g';
let examList = ref<Exam[]>([]);

onMounted(async () => {
  console.log("Home page mounted");
  let client = new ExamApiClient();
  const response = client.$makeCaller("list", methods => methods.list());
  await response();
  examList.value = response.result as Exam[];
  examList.value = toRaw(examList.value);
  console.log(examList.value);
});
</script>
