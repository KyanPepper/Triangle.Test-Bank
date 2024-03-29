<template>
  <div class="exam-card-container">
    <ExamCard v-for="exam in examList" :key="exam.examId" :name="exam.name" :term="TermToText(Number(exam.term))"
      :subject="SubjectToText(Number(exam.subject))" :pdf="exam.pdfPath"></ExamCard>
  </div>
</template>

<style scoped>
.exam-card-container {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
  padding: 30px;
}
</style>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { ExamApiClient } from "@/api-clients.g";
import { Exam } from "@/models.g";
import { TermToText, SubjectToText } from "@/helperfunctions";
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
