import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export enum Subjects {
  CPTS = 0,
  MATH = 1,
  ENGR = 2,
  PHYS = 3,
  CHEM = 4,
  BIO = 5,
  EE = 6,
  ME = 7,
  CE = 8,
  MSE = 9,
  STAT = 10,
  CSTM = 11,
}


export enum Terms {
  Fall2021 = 0,
  Spring2021 = 1,
  Fall2022 = 2,
  Spring2022 = 3,
  Fall2023 = 4,
  Spring2023 = 5,
  Fall2024 = 6,
  Spring2024 = 7,
}


export interface Exam extends Model<typeof metadata.Exam> {
  examId: number | null
  name: string | null
  subject: Subjects | null
  term: Terms | null
  pdfPath: string | null
}
export class Exam {
  
  /** Mutates the input object and its descendents into a valid Exam implementation. */
  static convert(data?: Partial<Exam>): Exam {
    return convertToModel(data || {}, metadata.Exam) 
  }
  
  /** Maps the input object and its descendents to a new, valid Exam implementation. */
  static map(data?: Partial<Exam>): Exam {
    return mapToModel(data || {}, metadata.Exam) 
  }
  
  /** Instantiate a new Exam, optionally basing it on the given data. */
  constructor(data?: Partial<Exam> | {[k: string]: any}) {
    Object.assign(this, Exam.map(data || {}));
  }
}


