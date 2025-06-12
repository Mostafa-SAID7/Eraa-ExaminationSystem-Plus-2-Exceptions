# 📝 Console Exam System (C# .NET 9)

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
