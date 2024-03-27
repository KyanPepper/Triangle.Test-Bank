<template>
  <ExamCard />
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { ExamApiClient } from "@/api-clients.g";
import { Exam } from "@/models.g";
const examList = ref<Exam[]>([]);

onMounted(async () => {
  console.log("Home page mounted");
  const client = new ExamApiClient();
  const response = client.$makeCaller("list", (methods) => methods.list());
  await response();
  examList.value = response.result as Exam[];
  console.log(examList.value);
});
</script>
