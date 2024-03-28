<template>
  <VContainer class="">
    <VForm class="h-full">
      <VTextField v-model="examState.name" label="Exam Name" required />
      <v-select v-model="examState.subject" :items="subjectItems" label="Subject" required />
      <v-select v-model="examState.term" label="Term" required :items="termItems"/>
      <VFileInput v-model="examState.pdf" label="Exam File" required />
      <VBtn color="primary" @click="uploadExam">
        Upload Exam
      </VBtn>
    </VForm>
  </VContainer>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { TermToText,SubjectToText } from '@/helperfunctions';



interface ExamModel {
  name: string;
  subject: string | null;
  term: string | null;
  pdf: any | null;
}

export default defineComponent({

  setup() {
    const examState = ref<ExamModel>({
      name: '',
      subject: null,
      term: null,
      pdf: null
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

    const uploadExam = () => {
      console.log('Upload exam clicked');
      console.log(examState.value.pdf);
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