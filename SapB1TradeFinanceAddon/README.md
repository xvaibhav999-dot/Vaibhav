# SAP Business One Trade Finance Add-on (HANA)

This add-on provides starter implementation for:
- Letter of Credit lifecycle capture
- Bank Guarantee lifecycle capture

## Stack
- Visual Studio 2019
- .NET Framework 4.8
- SAP Business One UI API (`SAPbouiCOM`)
- SAP Business One DI API (`SAPbobsCOM`)
- SAP B1 on HANA

## Setup
1. Copy `Interop.SAPbouiCOM.dll` and `Interop.SAPbobsCOM.dll` into `lib/`.
2. Build the solution in VS2019.
3. Package and register as an SAP B1 add-on (ARD).
4. Ensure forms `UDO_FT_TF_LC` and `UDO_FT_TF_BG` exist (Screen Painter or B1 Studio).

## Functional notes
- On startup, the add-on creates UDTs `@TF_LC` and `@TF_BG` and required UDFs if missing.
- Menu path: **Modules -> Trade Finance -> Letter of Credit / Bank Guarantee**.
- Form controllers persist records to UDT tables on Add/OK button press.

## Extend next
- Add approval workflow by amount thresholds.
- Integrate alerts for expiry reminders.
- Add document attachments and downstream journal entries.
- Add update/cancel and robust validation/error handling.
