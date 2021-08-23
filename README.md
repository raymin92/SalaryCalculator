


<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://https://github.com/raymin92/SalaryCalculator">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Salary Calculator</h3>
</p>

<!-- ABOUT THE PROJECT -->
## About The Project

There are many great Salary Calculators available, however, this one is the best.

Here's why:
* To comply with Interface Segration Principlae and Separation of Concerns, Option pattern is used to set tax laws related values. Also, separated salary generation and reporting services.
* Dependancy injection design pattern is used for achieving Inversion of Control between classes and their dependencies.
* Unit testing using XUnit has covered the core calculation logic, which gives user more confidence.
* Essentially, the logic to calculate medicare levy, budget repair levy and income tax is identical. So I extract the common part out into a base class and let those inherit from the base class. Medicare levy has an exception, so the method was overriden a little bit.
* Extension methods is used to add methods to enum without creating a new derived type.

To apply income rules change in the future or apply past rules for auditing, you can simply create different groups of app settings without changing any code. For more complex scenarios, I believe it won't too hard to refactor given the flexibility of current implementaion.

### Built With

This section should list any major frameworks that you built your project using. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.
* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* [XUnit](https://xunit.net/)



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

You are all set.

### Installation

1. Clone the repo
   ```sh
   git clone git@github.com:raymin92/SalaryCalculator.git
   ```
2. Run SalaryCalculator Project



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request




<!-- CONTACT -->
## Contact

Ray Min - rayminyxc@gmail.com
