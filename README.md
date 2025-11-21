Part 1 of the POE
Overview
This project is a prototype for a web-based Lecturer Claims Management System designed to simplify the submission, verification, and processing of lecturer claims.It was developed using ASP.NET MVC (C#) to model the user interface, workflows, and navigation before implementing full functionality in Part 2.the goal of Part 1 was to design the front-end structure and logical flow of the system, focusing on user experience, layout consistency, and role-based dashboards.

Objectives
To create a user-friendly prototype interface for the claims management system.
To design separate views and navigation for:
Lecturers submit claims and view their claim history.
Programme coordinators view review, approve, or reject claims.
Academic managers view to process approved claims and generate reports.

Technologies Used
C#
ASP.NET MVC
Visual Studio

Limitations 
No real database data handled with in-memory lists.Buttons and forms simulated; no backend logic.File uploads and totals not stored persistently.
Basic styling no external CSS or javaScript frameworks.


Part 2 of the POE
Overview
The Monthly Contract Claim Management System is a web-based ASP.NET MVC application designed to streamline and automate the process of submitting, approving, and processing lecturer claims within an academic environment.
The system provides separate dashboards for Lecturers, Coordinators, and Managers, ensuring transparency, accountability, and efficient claim handling from submission to final approval.

Objectives
Simplify the claim submission and review process.
Maintain accurate claim records and history tracking.
Support multiple user roles with specific responsibilities.
Enable document upload, download, and reporting.

Workflow
Lecturer
Submits a new claim form with relevant details hours worked, hourly rate, claim title, user name, claim month, description).Uploads supporting documents PDF, DOCX, JPG, PNG and has a file size limit.Can filter, view, and download previous claims.
Automatically calculates claim total hours × hourly rate.Claim status updates pending ,approved or rejected.

Programme Coordinators
Reviews lecturer claims and verifies them.Approves or rejects claims.Tracks recent activity and view claim history.Generates monthly reports and analytics.

Academic Managers
Final stage of claim processing.Views all approved claims for processing.Marks claims as processed and records history.Views uploaded documents and generates downloadable reports.

Features
-Claim Submission Form:Lecturer name, date, title, description, hours, rate, and file upload.
-Auto-calculated total amount.
-Claim History Tracking
-Logs every action submitted, approved, rejected, processed with timestamps and performer.
-Dashboards per Role
-Lecturer: Quick access, claim summary, recent activity.
-Coordinator: Manage lecturers, verify pending claims, generate reports.
-Manager: Process final claims, view reports, and feedback actions.
-Filtering and Search:Filter claims by date and status.
-Document Management: Upload and view claim-related documents.

Technologies used
Razor Views 
HTML, CSS, Bootstrap style inline
ASP.NET Core MVC.NET 9
Database	Microsoft SQL Server with Entity Framework Core
Coding Language	C#
IDE	Visual Studio 
File Handling	IWebHostEnvironment for uploads

How to Use
Directed to the Lecturer Dashboard.
Submit new claims via Create New Claim.
Coordinator reviews claims approves or rejects.
Manager finalizes processes approved claims.
History updates and reports can be downloaded.
Login page to authenticate users by their user roles
 

Database design
Consisted of 6 tables
User
User Role
Document
Lecturer Report
Claim
Login

Overview
Part 3 represents the full implementation phase of the Monthly Contract Claim Management System.
Unlike Part 1 (prototype) and Part 2 (partial backend integration), this stage delivers a complete, functional system with:
-A connected SQL Server database
-Real authentication
-Role-based redirection
-Claim workflow automation
-HR user management
-File uploads
-Fully functional dashboards
-Reporting and audit features

Objectives in Part 3
Full Database Integration Using Entity Framework Core
-Creation of database tables using migrations
-Seeding of default users and roles
-Full CRUD operations for Users, Claims, and Reviews
-Joins using Include() for dashboard summaries

Fully Working Authentication System
-Login page validates credentials against the database
-Password and email must match existing user records
-Role-based login redirection:

-Lecturer → Lecturer Dashboard
-Programme Coordinator → Coordinator Dashboard
-Academic Manager → Manager Dashboard
-HR → HR Dashboard

1.Lecturer Claim Management
Lecturers can:
-Submit new monthly contract claims
-Upload supporting documents
-Automatically calculate totals (Hours × Hourly Rate)
-View claim statuses (Pending, Approved, Rejected)
-Track recent activity

2.Programme Coordinator Claim Review
Coordinators can:
-View all submitted claims
-Approve or reject claims
-Add comments
-View claim history and status distribution
-Access reports and analytics

3.Academic Manager Final Approval
Managers can:
-View all coordinator-approved claims
-Finalise approval or rejection
-Process financial totals
-View analytics and historical records
-Access audit trail items

4.HR User Management
HR admins can:
-Create new system users
-Assign roles (Lecturer, Coordinator, Manager, HR)
-Edit user details
-View all registered users
-Generate financial and claim reports

5.Document Upload & Storage
-The system supports document uploads (PDF, Word, Images):
-Validates file size
-Generates unique filenames
-Stores files in wwwroot/uploads
-Allowed file extensions enforced

6.Reporting Features
HR and Managers can download PDF reports that include:
-Lecturer totals
-Monthly totals
-Claim summaries
-Financial breakdowns
Reports include:
-Claim ID
-Module
-Hours worked
-Amount
-Status
-Submission date

7.Enhanced GUI & UX
The system uses:
-Bootstrap 5 for styling
-Responsive dashboards
-Quick-access action buttons
-Summary cards
-Analytics sections
-Navigation menus
-Clean, modern interface

Technologies Used
-Frontend
-ASP.NET Razor Views
-HTML5 / Bootstrap 5
-Partial views for layout consistency
-Backend
-ASP.NET Core MVC
-C#
-Entity Framework Core
-LINQ queries
-iText7 for PDF report generation
-Database
-SQL Server
-Seed Data for Roles and Users

How the System Works 
-Lecturer → Coordinator → Manager → HR
-Lecturer submits monthly claim
-Coordinator reviews & approves/rejects
-Manager finalises the claim
-HR manages users and generates summary reports
-Delivered Project Outcomes (Rubric-Aligned)
-Required Feature	Implemented
-Full working MVC system	
-Role-based login	
-Dashboards per role	
-Document upload	
-Reporting & downloads	
-Clean UI	
Validation & error handling	
