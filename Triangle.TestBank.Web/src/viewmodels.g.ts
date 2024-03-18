import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ExamViewModel extends $models.Exam {
  examId: number | null;
  name: string | null;
  subject: $models.Subjects | null;
  term: $models.Terms | null;
  pdfPath: string | null;
}
export class ExamViewModel extends ViewModel<$models.Exam, $apiClients.ExamApiClient, number> implements $models.Exam  {
  
  constructor(initialData?: DeepPartial<$models.Exam> | null) {
    super($metadata.Exam, new $apiClients.ExamApiClient(), initialData)
  }
}
defineProps(ExamViewModel, $metadata.Exam)

export class ExamListViewModel extends ListViewModel<$models.Exam, $apiClients.ExamApiClient, ExamViewModel> {
  
  constructor() {
    super($metadata.Exam, new $apiClients.ExamApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Exam: ExamViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Exam: ExamListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

