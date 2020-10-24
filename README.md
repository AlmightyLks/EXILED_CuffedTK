# CuffedTK

A simple SCP SL [EXILED](https://github.com/galaxy119/EXILED/releases/tag/2.1.8) Plugin to handle Cuffed-Teamkilling.<br>
The following scenarios will trigger actions by the plugin:<br>

- Cuffed D-Bois hurt/killed by
  - Scientist
  - Facility Guard
  - NTF/MTF
- Cuffed Scientist hurt/killed by
  - Chaos Insurgency
  - D-Boi
---
### Resources used

- .NET Framework 4.7.2 Class Library
- **EXILED** Library | Version 2.1.8

---
### Actions

The Victim gets all necessary info to report the occurence to the server staff.
<br>The Server console logs the same info to match.<br>

---
### Toggling **[Remote Admin Console]**

Automatic jailing on teamkilling:<br>
- autojail
- aj

Damage prevention:<br>
- pdmg

Damage reflection:<br>
- rdmg

---
### Configs

Three out of the four configs are boolean values and can either be `true` / `false`.  
By default and if not configured, they're all false.  
For the webhook url, it is by default an empty string. Place your Discord Channel Webhook into the simple quotation marks and you're good to go.

Example:  

```
  # Auto jailing on Cuffed Teamkilling
  auto_jail: false
  # Damage prevention on attempted Cuffed Teamkilling
  prevent_damage: false
  # Damage reflection on attempted Cuffed Teamkilling
  reflect_damage: false
  # Webhook url
  webhook_url: ''
```

