# Desktop Logger - Hidden System Activity Logger

Desktop Logger is a stealthy C#-based application that logs system activities, keystrokes, clipboard content, and more while running silently in the background. The logs are stored in a hidden location and can be accessed remotely or uploaded to the cloud.

## Features
- **Keystroke Logging**: Captures all typed keystrokes.
- **Clipboard Monitoring**: Logs copied text and clipboard activity.
- **Mouse Tracking**: Monitors mouse clicks and movements.
- **Active Window Logging**: Detects and records the currently active window.
- **System Events Tracking**: Logs application open/close events.
- **Screenshot Capture**: Periodically captures screenshots for visual tracking.
- **USB Activity Logging**: Detects USB plug/unplug events.
- **Stealth Mode**: Runs in the background without user detection.
- **Hidden Log Storage**: Saves logs in an encrypted, hidden folder.
- **Disguised Process**: Appears as a system service to avoid suspicion.
- **Remote Log Access**: Sends logs via email, Telegram, or auto-uploads to the cloud.
- **Auto-Restart**: Relaunches if terminated via Task Manager.

## Technologies Used
- **Language**: C# (.NET 8.0)
- **Data Storage**: Local encrypted files / SQLite / Remote cloud storage
- **Networking**: Secure remote access via email, Telegram, or FTP
- **Security**: Process disguise and auto-restart functionality

## Installation Guide
### Prerequisites
- Windows OS (10 or later)
- .NET 8.0 SDK installed
- Visual Studio or VS Code

### Steps to Install
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/desktop-logger.git
   ```
2. Open the project in Visual Studio or VS Code.
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Build and run the application:
   ```sh
   dotnet run
   ```
5. The logger will start running in the background.

## Usage
1. **Stealth Execution**: The application runs hidden without a visible UI.
2. **Log Retrieval**: View logs stored in the hidden directory or set up email/Telegram auto-send.
3. **Stop Logger**: Use predefined hotkeys or a remote command to stop logging.
4. **Enable/Disable Specific Features**: Modify the config file to enable/disable certain logging functions.

## Screenshots
![Log File](screenshots/logs.png)
![Settings Panel](screenshots/settings.png)

## Future Enhancements
- Encrypted logs with password protection.
- AI-based key pattern detection.
- Web-based control panel for managing logs remotely.
- Multi-user activity tracking with timestamps.

## Contributing
Pull requests are welcome! Feel free to submit issues and suggestions.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
For any queries or suggestions, contact: [your email or website]

