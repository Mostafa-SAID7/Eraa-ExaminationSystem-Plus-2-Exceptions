# Security Policy

## Supported Versions

The following table lists the versions of the Examination System project that are currently supported with security updates:

| Version | Supported |
|---------|-----------|
| 2.x     | ✅ Yes     |
| 1.x     | ❌ No      |

---

## Reporting a Vulnerability

If you discover a security vulnerability in this project, please **do not create a public issue**.

Instead, please contact the author directly:

- **GitHub**: [@Mostafa-SAID7](https://github.com/Mostafa-SAID7)

We will respond as quickly as possible and coordinate with you to release a fix.

---

## Security Improvements in Latest Release

As of version `v2.0`, the following changes were made to improve security and data integrity:

- ✅ Validation for question types and formats.
- ✅ Time input (exam duration) now strictly validated using `TimeSpan.TryParse`.
- ✅ Duplicate MCQ options are no longer allowed to prevent ambiguity.
- ✅ Clean user input handling for marks and headers to avoid runtime exceptions.
- ✅ All emoji and decorative console elements removed to reduce parsing risks in CI/CD environments.

---

## Recommendations for Users

- Always run the app in a secure terminal.
- Validate any future enhancements with unit testing.
- Ensure your .NET runtime is updated (minimum .NET 9 supported).

---

## License

This project is licensed under the **MIT License**.
