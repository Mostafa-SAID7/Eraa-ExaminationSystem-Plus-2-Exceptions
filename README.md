# 📝 Console Exam System (C# .NET 9)
<div style="display: flex; justify-content: space-between; align-items: center;">
  <h1 style="margin: 0;">Eraa-StudentManagementSystem</h1>
  <p align="center">
 <a href="https://drive.google.com/file/d/1nDRjhbqct12RlGyURuJaomuu0FQKosYx/view?usp=sharing" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/PDF-View%20Struct%20vs%20Class%20vs%20Record-D44638?style=flat&logo=adobe&logoColor=white" alt="View PDF" />
  </a>
  <a href="https://www.facebook.com/eraasoft" target="_blank" rel="noopener noreferrer">
    <img src="https://img.shields.io/badge/Built%20with-Eraa%20Soft%20Training%20Program-1877F2?style=flat&logo=facebook&logoColor=white" alt="Eraa Soft Training Program" />
  </a>
 <a href="https://github.com/Mostafa-SAID7" target="_blank" rel="noopener noreferrer">
  <img src="https://img.shields.io/badge/Author-Mostafa--SAID7-000?style=flat&logo=github&logoColor=white" alt="Author: Mostafa-SAID7" />
</a>
  </p>
</div>
A console-based examination system built in C# using .NET 9. Supports two question types and includes exam timing, grading, and midpoint progress notification.

---

## 📌 Features

- ✅ Two question types:
  - True/False
  - Multiple Choice (Choose All Correct Answers)
- 🧠 Create custom questions with:
  - Header
  - Marks
  - Correct answer(s)
- 🚫 Prevent duplicate options in MCQs
- 🕒 Set total exam duration (in minutes)
- ⏳ Midpoint time warning during exam
- 🔐 Answer validation & scoring
- 🧮 Auto calculates total marks and grade
- ⏱️ Displays time spent after exam completion
- 🔔 Notifies all students when exam starts
- 🔄 Clean OOP structure with inheritance and events

---

## 🚀 How It Works

1. App asks how many questions to create
2. For each question:
   - Select type (True/False or MCQ)
   - Enter header
   - Enter mark
   - Enter correct answer(s)
3. Choose to start the exam or exit
4. Provide exam time limit
5. Exam begins:
   - Questions shown one by one
   - User enters answers
   - Midpoint message shown halfway through the exam
6. Final results are displayed:
   - Grade
   - Total marks
   - Time spent

---

## 🛠 Tech Stack

- .NET 9
- C# Console Application
