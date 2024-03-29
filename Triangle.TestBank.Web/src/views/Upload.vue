<template>
  <VContainer class="">
    <VForm class="h-full">
      <VTextField v-model="examState.name" label="Exam Name" required />
      <v-select v-model="examState.subject" :items="subjectItems" label="Subject" required />
      <v-select v-model="examState.term" label="Term" required :items="termItems" />
      <VFileInput v-model="examState.pdf" label="Exam File" required />
      <VBtn color="primary" @click="uploadExam">
        Upload Exam
      </VBtn>
    </VForm>
  </VContainer>
</template>

<script lang="ts">
import { defineComponent, ref, toRaw } from 'vue';
import { TermToNum, SubjectToNum } from '@/helperfunctions';
import { ExamServicesApiClient } from '@/api-clients.g';


interface ExamModel {
  name: string;
  subject: string | null;
  term: string | null;
  pdf: File[];
}

export default defineComponent({

  setup() {
    const examState = ref<ExamModel>({
      name: '',
      subject: null,
      term: null,
      pdf: []
    });
    const subjectItems = [
      "CPTS",
      "MATH",
      "ENGR",
      "PHYS",
      "CHEM",
      "BIO",
      "EE",
      "ME",
      "CE",
      "MSE",
      "STAT",
      "CSTM",
    ];

    const termItems = [
      "Fall 2021",
      "Spring 2021",
      "Fall 2022",
      "Spring 2022",
      "Fall 2023",
      "Spring 2023",
      "Fall 2024",
      "Spring 2024",
    ];

    const uploadExam = async () => {
      let pdfArg: File[] = toRaw(examState.value.pdf);
      console.log(pdfArg);

      const client = new ExamServicesApiClient();
      let subArg = SubjectToNum(examState.value.subject);
      let termArg = TermToNum(examState.value.term);
      const response = await client.$makeCaller("item", (methods) => methods.postExam(examState.value.name, subArg, termArg, pdfArg[0]));
      await response();
      console.log(response);
    };

    return {
      examState,
      uploadExam,
      subjectItems,
      termItems
    };
  }
});
</script>