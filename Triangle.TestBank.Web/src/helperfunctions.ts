export function SubjectToText(enumValue: number): string {
  switch (enumValue) {
    case 0:
      return "CPTS";
    case 1:
      return "MATH";
    case 2:
      return "ENGR";
    case 3:
      return "PHYS";
    case 4:
      return "CHEM";
    case 5:
      return "BIO";
    case 6:
      return "EE";
    case 7:
      return "ME";
    case 8:
      return "CE";
    case 9:
      return "MSE";
    case 10:
      return "STAT";
    case 11:
      return "CSTM";
    default:
      return "Unknown";
  }
}
export function TermToText(enumValue: number): string {
  switch (enumValue) {
    case 0:
      return "Fall 2021";
    case 1:
      return "Spring 2021";
    case 2:
      return "Fall 2022";
    case 3:
      return "Spring 2022";
    case 4:
      return "Fall 2023";
    case 5:
      return "Spring 2023";
    case 6:
      return "Fall 2024";
    case 7:
      return "Spring 2024";
    default:
      return "Unknown";
  }
}
