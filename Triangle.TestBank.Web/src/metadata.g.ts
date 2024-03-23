import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const Subjects = domain.enums.Subjects = {
  name: "Subjects",
  displayName: "Subjects",
  type: "enum",
  ...getEnumMeta<"CPTS"|"MATH"|"ENGR"|"PHYS"|"CHEM"|"BIO"|"EE"|"ME"|"CE"|"MSE"|"STAT"|"CSTM">([
  {
    value: 0,
    strValue: "CPTS",
    displayName: "CPTS",
  },
  {
    value: 1,
    strValue: "MATH",
    displayName: "MATH",
  },
  {
    value: 2,
    strValue: "ENGR",
    displayName: "ENGR",
  },
  {
    value: 3,
    strValue: "PHYS",
    displayName: "PHYS",
  },
  {
    value: 4,
    strValue: "CHEM",
    displayName: "CHEM",
  },
  {
    value: 5,
    strValue: "BIO",
    displayName: "BIO",
  },
  {
    value: 6,
    strValue: "EE",
    displayName: "EE",
  },
  {
    value: 7,
    strValue: "ME",
    displayName: "ME",
  },
  {
    value: 8,
    strValue: "CE",
    displayName: "CE",
  },
  {
    value: 9,
    strValue: "MSE",
    displayName: "MSE",
  },
  {
    value: 10,
    strValue: "STAT",
    displayName: "STAT",
  },
  {
    value: 11,
    strValue: "CSTM",
    displayName: "CSTM",
  },
  ]),
}
export const Terms = domain.enums.Terms = {
  name: "Terms",
  displayName: "Terms",
  type: "enum",
  ...getEnumMeta<"Fall2021"|"Spring2021"|"Fall2022"|"Spring2022"|"Fall2023"|"Spring2023"|"Fall2024"|"Spring2024">([
  {
    value: 0,
    strValue: "Fall2021",
    displayName: "Fall 2021",
  },
  {
    value: 1,
    strValue: "Spring2021",
    displayName: "Spring 2021",
  },
  {
    value: 2,
    strValue: "Fall2022",
    displayName: "Fall 2022",
  },
  {
    value: 3,
    strValue: "Spring2022",
    displayName: "Spring 2022",
  },
  {
    value: 4,
    strValue: "Fall2023",
    displayName: "Fall 2023",
  },
  {
    value: 5,
    strValue: "Spring2023",
    displayName: "Spring 2023",
  },
  {
    value: 6,
    strValue: "Fall2024",
    displayName: "Fall 2024",
  },
  {
    value: 7,
    strValue: "Spring2024",
    displayName: "Spring 2024",
  },
  ]),
}
export const Exam = domain.types.Exam = {
  name: "Exam",
  displayName: "Exam",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Exam",
  get keyProp() { return this.props.examId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    examId: {
      name: "examId",
      displayName: "Exam Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    subject: {
      name: "subject",
      displayName: "Subject",
      type: "enum",
      get typeDef() { return domain.enums.Subjects },
      role: "value",
      rules: {
        required: val => val != null || "Subject is required.",
      }
    },
    term: {
      name: "term",
      displayName: "Term",
      type: "enum",
      get typeDef() { return domain.enums.Terms },
      role: "value",
      rules: {
        required: val => val != null || "Term is required.",
      }
    },
    pdfPath: {
      name: "pdfPath",
      displayName: "Pdf Path",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Pdf Path is required.",
      }
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const ExamServices = domain.services.ExamServices = {
  name: "ExamServices",
  displayName: "Exam Services",
  type: "service",
  controllerRoute: "ExamServices",
  methods: {
    healthCheck: {
      name: "healthCheck",
      displayName: "Health Check",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "string",
        role: "value",
      },
    },
    postExam: {
      name: "postExam",
      displayName: "Post Exam",
      transportType: "item",
      httpMethod: "POST",
      params: {
        name: {
          name: "name",
          displayName: "Name",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Name is required.",
          }
        },
        subject: {
          name: "subject",
          displayName: "Subject",
          type: "enum",
          get typeDef() { return domain.enums.Subjects },
          role: "value",
        },
        term: {
          name: "term",
          displayName: "Term",
          type: "enum",
          get typeDef() { return domain.enums.Terms },
          role: "value",
        },
        file: {
          name: "file",
          displayName: "File",
          type: "file",
          role: "value",
          rules: {
            required: val => val != null || "File is required.",
          }
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "model",
        get typeDef() { return (domain.types.Exam as ModelType) },
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
    Subjects: typeof Subjects
    Terms: typeof Terms
  }
  types: {
    Exam: typeof Exam
  }
  services: {
    ExamServices: typeof ExamServices
  }
}

solidify(domain)

export default domain as unknown as AppDomain
