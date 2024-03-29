<template>
  <VContainer class="">
    <VForm class="h-full">
      <VTextField v-model="examState.name" label="Exam Name" required />
      <v-select
        v-model="examState.subject"
        :items="subjectItems"
        label="Subject"
        required
      />
      <v-select
        v-model="examState.term"
        label="Term"
        required
        :items="termItems"
      />
      <VFileInput v-model="examState.pdf" label="Exam File" required />
      <VBtn color="red" @click="uploadExam" v-if="!uploadDone">
        Upload Exam
      </VBtn>
      <VAlert v-if="uploadDone" type="success" dismissible>
        Exam Uploaded Successfully
      </VAlert>
    </VForm>
  </VContainer>
</template>

<script lang="ts">
import { defineComponent, ref, toRaw } from "vue";
import {
  TermToNum,
  SubjectToNum,
  subjectItems,
  termItems,
} from "@/helperfunctions";
import { ExamServicesApiClient } from "@/api-clients.g";

interface ExamModel {
  name: string;
  subject: string | null;
  term: string | null;
  pdf: File[];
}

export default defineComponent({
  setup() {
    const examState = ref<ExamModel>({
      name: "",
      subject: null,
      term: null,
      pdf: [],
    });
    let uploadDone = ref(false);

    const uploadExam = async () => {
      let pdfArg: File[] = toRaw(examState.value.pdf);
      const client = new ExamServicesApiClient();
      let subArg = SubjectToNum(examState.value.subject);
      let termArg = TermToNum(examState.value.term);
      const response = await client.$makeCaller("item", (methods) =>
        methods.postExam(examState.value.name, subArg, termArg, pdfArg[0]),
      );
      await response();
      if (response.wasSuccessful) {
        uploadDone.value = true;
      }
    };

    return {
      examState,
      uploadExam,
      subjectItems,
      termItems,
      uploadDone,
    };
  },
});
</script>