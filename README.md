# Task Management System

## Database Schema

### Employees Table
```sql
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    ManagerId INT NULL,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Admin', 'Manager', 'Employee'))
);
```
### Teams Table
```sql
CREATE TABLE Teams (
    TeamId INT PRIMARY KEY IDENTITY(1,1),
    TeamName NVARCHAR(100) NOT NULL,
    ManagerId INT NOT NULL
);
```
### Tasks Table
```sql
CREATE TABLE Tasks (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    AssignedTo INT NOT NULL,
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'InProgress', 'Completed')),
    DueDate DATETIME NOT NULL,
    CreatedBy INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
```

### TaskNotes Table
```sql
CREATE TABLE TaskNotes (
    NoteId INT PRIMARY KEY IDENTITY(1,1),
    TaskId INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedBy INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
```
### TaskAttachments Table
```sql
CREATE TABLE TaskAttachments (
    AttachmentId INT PRIMARY KEY IDENTITY(1,1),
    TaskId INT NOT NULL,
    FilePath NVARCHAR(MAX) NOT NULL,
    UploadedBy INT NOT NULL,
    UploadedDate DATETIME NOT NULL DEFAULT GETDATE()
);
```
## Insert Values
### Insert Employees
```sql
INSERT INTO Employees (Name, Email, Role) VALUES ('John Doe', 'john.doe@example.com', 'Admin');
INSERT INTO Employees (Name, Email, Role) VALUES ('Jane Smith', 'jane.smith@example.com', 'Manager');
-- Assume the ManagerId for Jane Smith is 2
INSERT INTO Employees (Name, Email, ManagerId, Role) VALUES ('Sam Wilson', 'sam.wilson@example.com', 2, 'Employee');

-- Additional Inserts
INSERT INTO Employees (Name, Email, Role) VALUES ('Alice Brown', 'alice.brown@example.com', 'Manager');
INSERT INTO Employees (Name, Email, ManagerId, Role) VALUES ('Bob Taylor', 'bob.taylor@example.com', 2, 'Employee');
INSERT INTO Employees (Name, Email, ManagerId, Role) VALUES ('Charlie Green', 'charlie.green@example.com', 4, 'Employee');
INSERT INTO Employees (Name, Email, Role) VALUES ('David White', 'david.white@example.com', 'Admin');
INSERT INTO Employees (Name, Email, ManagerId, Role) VALUES ('Eve Black', 'eve.black@example.com', 2, 'Employee');
```

### Insert Teams
```sql
-- Assume the ManagerId for Jane Smith is 2
INSERT INTO Teams (TeamName, ManagerId) VALUES ('Development Team', 2);

-- Additional Inserts
INSERT INTO Teams (TeamName, ManagerId) VALUES ('Design Team', 4);
INSERT INTO Teams (TeamName, ManagerId) VALUES ('QA Team', 2);
```

### Insert Tasks
```sql
-- Assume the EmployeeId for Sam Wilson is 3, and Jane Smith is 2
INSERT INTO Tasks (Title, Description, AssignedTo, Status, DueDate, CreatedBy) 
VALUES ('Complete Backend', 'Develop the API layer', 3, 'Pending', '2024-08-15', 2);

-- Additional Inserts
INSERT INTO Tasks (Title, Description, AssignedTo, Status, DueDate, CreatedBy) 
VALUES ('Design Homepage', 'Create the main homepage design', 3, 'InProgress', '2024-08-20', 2);

INSERT INTO Tasks (Title, Description, AssignedTo, Status, DueDate, CreatedBy) 
VALUES ('Implement API', 'Develop the REST API for user management', 5, 'Pending', '2024-08-25', 2);

INSERT INTO Tasks (Title, Description, AssignedTo, Status, DueDate, CreatedBy) 
VALUES ('QA Testing', 'Perform QA testing on the new features', 6, 'Pending', '2024-08-22', 4);

INSERT INTO Tasks (Title, Description, AssignedTo, Status, DueDate, CreatedBy) 
VALUES ('Database Optimization', 'Optimize the database queries', 7, 'Pending', '2024-08-28', 2);
```

### Insert Task Notes
```sql
-- Assume TaskId for 'Design Homepage' is 1, and Sam Wilson (CreatedBy) is 3
INSERT INTO TaskNotes (TaskId, Content, CreatedBy) 
VALUES (1, 'Initial design draft completed.', 3);

-- Additional Inserts
INSERT INTO TaskNotes (TaskId, Content, CreatedBy) 
VALUES (2, 'Started implementing the user authentication.', 5);

INSERT INTO TaskNotes (TaskId, Content, CreatedBy) 
VALUES (3, 'Test cases are prepared.', 6);
```

### Insert Task Attachments
```sql
-- Assume TaskId for 'Design Homepage' is 1, and Sam Wilson (UploadedBy) is 3
INSERT INTO TaskAttachments (TaskId, FilePath, UploadedBy) 
VALUES (1, '/uploads/design_homepage_v1.png', 3);

-- Additional Inserts
INSERT INTO TaskAttachments (TaskId, FilePath, UploadedBy) 
VALUES (2, '/uploads/api_implementation_docs.pdf', 5);

INSERT INTO TaskAttachments (TaskId, FilePath, UploadedBy) 
VALUES (3, '/uploads/qa_test_cases.xlsx', 6);
```


## EXAMPLE API ENDPOINTS
### GET Employees
```json 
    GET: https://localhost:7237/api/Employee
    RESPONSE:
    [
        {
            "employeeId": 1,
            "name": "John Doe",
            "email": "john.doe@example.com",
            "managerId": null,
            "role": "Admin"
        },
        {
            "employeeId": 2,
            "name": "Jane Smith",
            "email": "jane.smith@example.com",
            "managerId": null,
            "role": "CEO"
        }
    ]
```
### Get Employee by ID
```json
    GET: https://localhost:7237/api/Employee/5
    RESPONSE:
    {
        "employeeId": 5,
        "name": "Charlie Davis",
        "email": "charlie.davis@example.com",
        "managerId": 3,
        "role": "Developer"
    }
```
### Create Employee
```json
    POST: https://localhost:7237/api/Employee
    PAYLOAD:
    {
        "employeeId": 6,
        "name": "David Wilson",
        "email": "david.wilson@example.com",
        "managerId": 3,
        "role": "Tester"
    }
    RESPONSE:
    {
        "employeeId": 6,
        "name": "David Wilson",
        "email": "david.wilson@example.com",
        "managerId": 3,
        "role": "Tester"
    }
```
### Update Employee
```json
    PUT: https://localhost:7237/api/Employee/5
    {
        "employeeId": 5,
        "name": "Charlie Davis",
        "email": "charlie.davis@newdomain.com",
        "managerId": 3,
        "role": "Senior Developer"
    }
```

### Delete Employee
```json
    DELETE: https://localhost:7237/api/Employee/5
    GET: https://localhost:7237/api/Report/TeamTaskReport
    {
        "Status": "Open",
        "TimeRange": "Month"
    }
    RESPONSE:
    [
        {
            "taskId": 3,
            "title": "Design Homepage",
            "description": "Create the layout and design for the new homepage.",
            "assignedTo": 8,
            "status": "Open",
            "dueDate": "2024-08-10T00:00:00",
            "createdBy": 4,
            "createdDate": "2024-08-09T15:38:36.07"
        },
        {
            "taskId": 1004,
            "title": "Design Login Page",
            "description": "Create a new design for the login page.",
            "assignedTo": 8,
            "status": "Open",
            "dueDate": "2024-08-13T00:00:00",
            "createdBy": 4,
            "createdDate": "2024-08-13T13:48:43.457"
        }
    ]
```