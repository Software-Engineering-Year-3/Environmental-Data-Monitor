# Environmental Data Monitor  
**Branch:** Report-Sensors-Accounts  

---

## Overview  
This branch contains the implementation of three core user stories for the Environmental Data Monitor MAUI app, independent of backend database integrations. It preserves the foundational navigation and UI ,while introducing mock-first data services and feature  pages to satisfy:

1. **Locate & Navigate to Sensors**  
2. **Report Sensor Malfunctions or Anomalies**  
3. **Manage User Access & Roles**  

---

##  User Stories  

### 1. Locate & Navigate to Sensors  
> **As an Environmental Scientist, I want to see all sensors on a map and zoom into a single device so that I can perform field maintenance or inspections.**  
- **Pages & ViewModels**  
  - `SensorDashboardPage` / `SensorDashboardViewModel`  
  - `SensorMapPage` / `SensorMapViewModel` (via Shell query parameters)  
- **Services**  
  - `SensorService.LoadMockSensors()` provides in-memory sensor locations.  
- **Key Behaviors**  
  - “View Map” button loads pins for all sensors.  
  - Tapping a specific sensor sends you to a map centred on that sensor.  

### 2. Report Sensor Malfunctions or Anomalies  
> **As a Field Technician, I want to report issues on a sensor so that maintenance teams can address anomalies.**  
- **Pages**  
  - `ReportIssuePage` (XAML + code-behind)  
- **Workflow**  
  1. Enter sensor name, description, and optional reporter name.  
  2. Tap **Submit Report** → display success alert → navigate back.  
  3. (Future) Hook into persistent storage or API endpoint.  

### 3. Manage User Access & Roles  
> **As an Administrator, I want to view, modify, and delete user accounts so that I can control access and maintain security.**  
- **Pages & ViewModels**  
  - `UserManagementPage` / `UserManagementViewModel`  
- **Services & Stores**  
  - `MockUserStore` for in-memory user data.  
  - `UserSession` to track the currently logged-in user.  
- **Key Features**  
  - List users in a `CollectionView` with pickers for role selection.  
  - Confirmation dialogs for role changes and deletions.  

---

##  Branch Contents  

- **Pages/**  
  - `SensorDashboardPage.xaml/.cs`  
  - `SensorMapPage.xaml/.cs`  
  - `ReportIssuePage.xaml/.cs`  
  - `UserManagementPage.xaml/.cs`  
- **ViewModels/**  
  - `SensorDashboardViewModel.cs`  
  - `AirQualityViewModel.cs`, `WaterQualityViewModel.cs`, `WeatherViewModel.cs`  
- **Data/Services/**  
  - `SensorService.cs` (mock sensor loader)  
  - `MockUserStore.cs`, `UserSession.cs`  
- **Resources/**  
  - `Raw/AirQualityData.csv`, `Raw/WaterQualityData.csv` (used by CSV loaders, with fallback to mocks)  


---

##  Setup & Run  

1. **Prerequisites**  
   - .NET 8.0 SDK  
   - Android SDK (for Android emulator or physical device)  
   - Visual Studio 2022 (with .NET MAUI workload)  

2. **Clone & Checkout**  
   ```bash
   git clone https://github.com/Software-Engineering-Year-3/Environmental-Data-Monitor.git
   cd Environmental-Data-Monitor
   git checkout Report-Sensors-Accounts
