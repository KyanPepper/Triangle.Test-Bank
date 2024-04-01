import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ExamApiClient extends ModelApiClient<$models.Exam> {
  constructor() { super($metadata.Exam) }
}


export class ExamServicesApiClient extends ServiceApiClient<typeof $metadata.ExamServices> {
  constructor() { super($metadata.ExamServices) }
  public healthCheck($config?: AxiosRequestConfig): AxiosPromise<ItemResult<string>> {
    const $method = this.$metadata.methods.healthCheck
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public postExam(name: string | null, subject: $models.Subjects | null, term: $models.Terms | null, file: File | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.Exam>> {
    const $method = this.$metadata.methods.postExam
    const $params =  {
      name,
      subject,
      term,
      file,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public checkPassCode(userInput: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<boolean>> {
    const $method = this.$metadata.methods.checkPassCode
    const $params =  {
      userInput,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


