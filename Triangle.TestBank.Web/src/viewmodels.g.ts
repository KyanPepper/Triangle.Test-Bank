import * as $metadata from "./metadata.g";
import * as $models from "./models.g";
import * as $apiClients from "./api-clients.g";
import {
  ViewModel,
  ListViewModel,
  ServiceViewModel,
  DeepPartial,
  defineProps,
} from "coalesce-vue/lib/viewmodel";

export interface ExamViewModel extends $models.Exam {
  examId: number | null;
  name: string | null;
  subject: $models.Subjects | null;
  term: $models.Terms | null;
  pdfPath: string | null;
}
export class ExamViewModel
  extends ViewModel<$models.Exam, $apiClients.ExamApiClient, number>
  implements $models.Exam
{
  constructor(initialData?: DeepPartial<$models.Exam> | null) {
    super($metadata.Exam, new $apiClients.ExamApiClient(), initialData);
  }
}
defineProps(ExamViewModel, $metadata.Exam);

export class ExamListViewModel extends ListViewModel<
  $models.Exam,
  $apiClients.ExamApiClient,
  ExamViewModel
> {
  constructor() {
    super($metadata.Exam, new $apiClients.ExamApiClient());
  }
}

export class ExamServicesViewModel extends ServiceViewModel<
  typeof $metadata.ExamServices,
  $apiClients.ExamServicesApiClient
> {
  public get healthCheck() {
    const healthCheck = this.$apiClient.$makeCaller(
      this.$metadata.methods.healthCheck,
      (c) => c.healthCheck(),
      () => ({}),
      (c, args) => c.healthCheck(),
    );

    Object.defineProperty(this, "healthCheck", { value: healthCheck });
    return healthCheck;
  }

  public get postExam() {
    const postExam = this.$apiClient.$makeCaller(
      this.$metadata.methods.postExam,
      (
        c,
        name: string | null,
        subject: $models.Subjects | null,
        term: $models.Terms | null,
        file: File | null,
      ) => c.postExam(name, subject, term, file),
      () => ({
        name: null as string | null,
        subject: null as $models.Subjects | null,
        term: null as $models.Terms | null,
        file: null as File | null,
      }),
      (c, args) => c.postExam(args.name, args.subject, args.term, args.file),
    );

    Object.defineProperty(this, "postExam", { value: postExam });
    return postExam;
  }

  public get checkPassCode() {
    const checkPassCode = this.$apiClient.$makeCaller(
      this.$metadata.methods.checkPassCode,
      (c, userInput: string | null) => c.checkPassCode(userInput),
      () => ({ userInput: null as string | null }),
      (c, args) => c.checkPassCode(args.userInput),
    );

    Object.defineProperty(this, "checkPassCode", { value: checkPassCode });
    return checkPassCode;
  }

  constructor() {
    super($metadata.ExamServices, new $apiClients.ExamServicesApiClient());
  }
}

const viewModelTypeLookup = (ViewModel.typeLookup = {
  Exam: ExamViewModel,
});
const listViewModelTypeLookup = (ListViewModel.typeLookup = {
  Exam: ExamListViewModel,
});
const serviceViewModelTypeLookup = (ServiceViewModel.typeLookup = {
  ExamServices: ExamServicesViewModel,
});
