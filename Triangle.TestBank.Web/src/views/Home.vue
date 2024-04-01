<template>
  <div class="search">
    <v-row>
      <v-col cols="12">
        <v-text-field
          v-model="searchQuery"
          label="Search"
          outlined
          clearable
          placeholder="Search exams by name"
        ></v-text-field>
      </v-col>
    </v-row>
  <div class="exam-card-container">
    
    <ExamCard
      v-for="exam in filteredExams"
      :key="exam.examId"
      :name="exam.name"
      :term="TermToText(Number(exam.term))"
      :subject="SubjectToText(Number(exam.subject))"
      :pdf="exam.pdfPath"
    ></ExamCard>
  </div>
  </div>
</template>

<style scoped>
.exam-card-container {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
  padding: 30px;
}
.search {
  margin: 20px;
}
</style>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { ExamApiClient } from "@/api-clients.g";
import { Exam } from "@/models.g";
import { TermToText, SubjectToText } from "@/helperfunctions";
import { VTextField } from "vuetify/lib/components/index.mjs";
const examList = ref<Exam[]>([]);
const searchQuery = ref<string>("");
onMounted(async () => {
  const client = new ExamApiClient();
  const response = client.$makeCaller("list", (methods) => methods.list());
  await response();
  examList.value = response.result as Exam[];
});
let filteredExams = computed(() => {
  return examList.value.filter(exam => {
    return exam.name && exam.name.toLowerCase().includes(searchQuery.value.toLowerCase());
  });
});
</script>
