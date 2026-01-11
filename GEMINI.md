# StudentManager - Project Context

## Project Overview
**StudentManager** is a C# .NET 10.0 Windows Forms application designed to solve a concrete problem (Student Grade Management) as part of a university project requirement.

The solution is structured to separate user interface logic from business logic, adhering to the requirement of using a reusable library.

### Architecture
The solution (`StudentManager.sln`) consists of two projects:
1.  **`StudentManager.UI`**: A Windows Forms application (`net10.0-windows`) that serves as the graphical user interface.
2.  **`StudentManager.Core`**: A Class Library (`net10.0`) containing the business logic, data models, and data persistence handling. This fulfills the "reusable library" requirement.

## Requirements Checklist
- [ ] Application Type: Windows Forms (Done)
- [ ] Concrete Problem: Student Grade Manager (In Progress)
- [ ] Data Collection: At least one vector/list (Pending implementation)
- [ ] Persistence: Save/Read data to file (txt, xml, json, db) (Pending implementation)
- [ ] Functions: Primary operations defined (Pending implementation)
- [ ] Library: Reusable library for logic (Done - `StudentManager.Core`)
- [ ] Reports: Generate at least one report file (Pending implementation)
- [ ] Validation: Validate all inputs (Pending implementation)

## Building and Running

### Prerequisites
- .NET 10.0 SDK

### Commands
*   **Build Solution:**
    ```powershell
    dotnet build
    ```
*   **Run Application:**
    ```powershell
    dotnet run --project StudentManager.UI
    ```

## Development Conventions

### Structure
*   **Logic:** All business entities (e.g., `Student` class) and file handling logic must reside in `StudentManager.Core`.
*   **UI:** Forms and event handlers reside in `StudentManager.UI`. The UI should only handle display and user input, delegating processing to the Core library.

### Coding Style
*   Use standard C# naming conventions (PascalCase for classes/methods, camelCase for local variables).
*   `Nullable` is enabled in both projects, so handle potential null references appropriately.
 dotnet run --project StudentManager.UI
 colectii List<Student>
  librarie folderul StudentManager.Core