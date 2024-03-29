# Triangle Test Bank (Iteration #1)
## Programer: Kyan Kotschevar-Smead

Demo: https://www.youtube.com/watch?v=DahI0efE69U&ab_channel=KyanKotschevar-Smead

Triangle Test Bank is a web application designed to serve as a test bank for WSU Triangle fraternity members, providing a platform for uploading and accessing previous exams. This project is intended for demonstration purposes only and is still being worked on.

## Features

- **Exam Upload**: Members can upload their exams to the platform securely.
- **Exam Viewing**: Users can view and download exams uploaded by other members, providing access to previous years' exams.

- **Technology Stack**: Built with Coalesce which facilitates .NET for backend development, Vue.js for frontend, MySQL for database management, and Azure Blob Storage for secure file storage.

## How to Run
1. Clone this repository.
2. Follow Coalesce docs for environment setup https://intellitect.github.io/Coalesce/stacks/vue/getting-started.html
3. cd .\Triangle.Test-Bank.Web\ npm ci
4. cd .\Triangle.Test-Bank.Data\  dotnet ef migrations add Init
5. Set up Azure Blob Storage and configure the connection in the DI container or Program.cs located in the web directory 
6. cd .\Triangle.Test-Bank.Web\ dotnet run
7. To run test cd .\Triangle.Test-Bank.Test\, configure Azure Blob Storage in ExamServiceTest, dotnet test
