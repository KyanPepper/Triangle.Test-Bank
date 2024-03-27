<template>

  <div>
    <ExamCard v-for="exam in examList" :key="exam.examId" :name="exam.name" :term="TermToText(Number(exam.term))"
      :subject="SubjectToText(Number(exam.subject))" :pdf="exam.pdfPath"></ExamCard>
  </div>

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

function SubjectToText(enumValue: number): string {
  switch (enumValue) {
    case 0:
      return "CPTS";
    case 1:
      return "MATH";
    case 2:
      return "ENGR";
    case 3:
      return "PHYS";
    case 4:
      return "CHEM";
    case 5:
      return "BIO";
    case 6:
      return "EE";
    case 7:
      return "ME";
    case 8:
      return "CE";
    case 9:
      return "MSE";
    case 10:
      return "STAT";
    case 11:
      return "CSTM";
    default:
      return "Unknown";
  }
}
function TermToText(enumValue: number): string {
  switch (enumValue) {
    case 0:
      return "Fall 2021";
    case 1:
      return "Spring 2021";
    case 2:
      return "Fall 2022";
    case 3:
      return "Spring 2022";
    case 4:
      return "Fall 2023";
    case 5:
      return "Spring 2023";
    case 6:
      return "Fall 2024";
    case 7:
      return "Spring 2024";
    default:
      return "Unknown";
  }
}

</script>
