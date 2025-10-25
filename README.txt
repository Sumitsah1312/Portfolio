SumitPortfolio - .NET 8 MVC sample portfolio (3D space theme)

How to run:
1. Ensure .NET 8 SDK is installed: `dotnet --version` (should be 8.x)
2. Open the folder /mnt/data/SumitPortfolio in Visual Studio, or open SumitPortfolio.csproj directly.
3. Build and Run (Ctrl+F5). The Home page contains a 3D developer cube and starfield powered by Three.js (loaded from CDN).

Notes:
- Three.js is loaded via CDN in the Home view. You can replace with a local three.min.js file if you prefer.
- Replace wwwroot/pdf/SumitShah_CV.pdf with your real CV.
- Customize content in Views/ to edit Education, Experience, Projects, and Contact pages.
