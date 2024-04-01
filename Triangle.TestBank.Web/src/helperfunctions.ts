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
export function SubjectToNum(textValue: string | null): number {
  switch (textValue) {
    case "CPTS":
      return 0;
    case "MATH":
      return 1;
    case "ENGR":
      return 2;
    case "PHYS":
      return 3;
    case "CHEM":
      return 4;
    case "BIO":
      return 5;
    case "EE":
      return 6;
    case "ME":
      return 7;
    case "CE":
      return 8;
    case "MSE":
      return 9;
    case "STAT":
      return 10;
    case "CSTM":
      return 11;
    default:
      return -1;
  }
}

export function TermToNum(textValue: string | null): number {
  switch (textValue) {
    case "Fall 2021":
      return 0;
    case "Spring 2021":
      return 1;
    case "Fall 2022":
      return 2;
    case "Spring 2022":
      return 3;
    case "Fall 2023":
      return 4;
    case "Spring 2023":
      return 5;
    case "Fall 2024":
      return 6;
    case "Spring 2024":
      return 7;
    default:
      return -1;
  }
}

export const subjectItems = [
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

export const termItems = [
  "Fall 2021",
  "Spring 2021",
  "Fall 2022",
  "Spring 2022",
  "Fall 2023",
  "Spring 2023",
  "Fall 2024",
  "Spring 2024",
];

export function GetCookie(cookieName:String) {
  const cookieString = document.cookie;
  const cookies = cookieString.split("; ");
  for (let i = 0; i < cookies.length; i++) {
    const cookie = cookies[i];
    const [name, value] = cookie.split("=");
    if (name === cookieName) {
 
      return decodeURIComponent(value);
    }
  }
  return null;
}