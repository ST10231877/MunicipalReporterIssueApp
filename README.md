# Municipal Reporter – Part 1

This is a Windows Forms (.NET Framework) application.  
It lets users report municipal issues such as water leaks, potholes, or streetlights.  
For this first version, only the **Report Issues** task is enabled.

---

How to Compile
1. Open **Visual Studio** on Windows.
2. Create a new project: **Windows Forms App (.NET Framework)**.
3. Target **.NET Framework 4.8**.
4. Copy all provided `.cs` files into the project:
   - `Program.cs`
   - `Models/Issue.cs`
   - `Services/AppState.cs`
   - `Forms/MainMenuForm.cs` + Designer
   - `Forms/ReportIssueForm.cs` + Designer
5. Build the project (**Ctrl+Shift+B**).
6. OR extract and import the original zip file by adding as a project.
---

How to Run
1. Press **F5** or click **Start Debugging** in Visual Studio.
2. The **Main Menu** window will open.
3. Only the **Report Issues** button is active for Part 1.

---

How to Use
1. From the Main Menu, click **Report Issues**.
2. Fill in the form:
   - **Title** – short description (e.g., “Burst pipe”).
   - **Location** – where the issue is.
   - **Category** – choose from dropdown.
   - **Description** – at least 10 characters.
   - **Attachment** – optional file (image or document).
3. Click **Submit**.
   - A progress bar and message will show while it submits.
   - On success, you’ll see a confirmation message and reference code.
4. Submitted issues will appear in the list on the right.
5. Click **Back to Main** to return to the menu.



Notes
- Issues are stored only in memory (they are cleared when you close the app).
- The other menu options are placeholders and will be added in later parts.
