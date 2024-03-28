<template>
    <VContainer class="">
      <VForm class="h-full">
        <VTextField
          v-model="examState.name"
          label="Exam Name"
          required
        />
        <v-select
          v-model="examState.subject"
          label="Subject"
          required
        />
        <v-select
          v-model="examState.term"
          label="Term"
          required
        />
        <VFileInput
          v-model="examState.pdf"
          label="Exam File"
          required
        />
        <VBtn color="primary" @click="uploadExam">
          Upload Exam
        </VBtn>
      </VForm>
    </VContainer>
  </template>
  
  <script lang="ts">
  import { defineComponent, ref } from 'vue';
  
  interface ExamModel {
    name: string;
    subject: number | null;
    term: number | null;
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
  
      const uploadExam = () => {
        console.log('Upload exam clicked');
        console.log(examState.value.pdf);
      };
  
      return {
        examState,
        uploadExam
      };
    }
  });
  </script>
  