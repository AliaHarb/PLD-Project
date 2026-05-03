#  AliaLang Compiler

**AliaLang** is a custom high-level programming language developed as part of the **Programming Languages Design (PLD)** course.  
This project implements a full compiler front-end including both a **Lexical Analyzer (Scanner)** and a **Syntax Analyzer (Parser)** using the **GOLD Parser Engine** and **C#**.

---

## 📌 Project Overview

AliaLang is designed to demonstrate the fundamental concepts of **compiler design** through a custom language with unique syntax and structured programming capabilities.

The system processes source code in two main phases:

1. **Lexical Analysis (Tokenization)**
2. **Syntax Analysis (Parsing & Validation)**

---

## Compiler Phases

### 1️⃣ Lexical Analysis (Scanner)
- Breaks source code into tokens
- Recognizes:
  - Keywords (`Launch`, `Check`, `Keep`, etc.)
  - Identifiers
  - Operators
  - Constants
- Detects invalid tokens and reports lexical errors

---

### 2️⃣ Syntax Analysis (Parser)
- Validates token sequence using grammar rules
- Built using **GOLD Parser Engine**
- Ensures correct structure of:
  - Conditions
  - Loops
  - Functions
- Provides detailed syntax error messages with expected tokens

---

##  Key Features

- 🔹 **Custom Language Syntax**
  - Keywords: `Launch`, `Terminate`, `Check`, `Otherwise`, `Keep`, `Pick`, `Action`

- 🔹 **Logical Expressions**
  - Supports:
    - `AND`
    - `OR`
    - `Reverse` (NOT)
  - Correct operator precedence handling

- 🔹 **Control Flow**
  - `Check` → if / else  
  - `Pick` → switch / case  
  - `Loop` → for  
  - `Keep` → while  

- 🔹 **Functions**
  - `Action` for definition  
  - Parameters support  
  - `Give_Back` for return  

- 🔹 **Error Handling**
  - Lexical errors (invalid tokens)
  - Syntax errors (unexpected structure)
  - Clear and descriptive messages

---

##  Language Syntax Example

```text
Launch
    Note: Defining a constant
    
    Fixed int score equal 100;
    
    Check (score > 50 AND Reverse(score == 0)) {
        show_Me("Status: Success");
    } Otherwise {
        show_Me("Status: Failed");
    }

Terminate
```

---

## 🛠️ Technologies Used

- **C# (.NET Framework)**
- **GOLD Parser Engine**
- **Calitha Parser Library**

---

## 📂 Project Structure

```bash
AliaLang-Compiler/
│
├── Grammar/
│   ├── AliaLang.grm
│   └── AliaLang.cgt
│
├── Source/
│   ├── Lexer/        # Tokenization logic
│   ├── Parser/       # Parsing logic
│   ├── UI/           # Interface (optional)
│   └── Main.cs
│
└── README.md
```

##  Output

- Token stream (from Lexical Analysis)
- Parsing validation result
- Error messages (if any)

---

##  Future Improvements

- 🔹 Semantic Analysis (type checking, scope)
- 🔹 Intermediate Code Generation
- 🔹 Code Optimization
- 🔹 GUI Enhancements
- 🔹 Syntax Highlighting Editor

---

##  Learning Outcomes

This project demonstrates strong understanding of:

- Lexical Analysis
- Syntax Analysis
- Context-Free Grammars (CFG)
- Parsing Techniques
- Compiler Design Workflow

---

##  Final Note

AliaLang is a complete **compiler front-end implementation**, combining both scanning and parsing phases to transform source code into a validated structured form.
