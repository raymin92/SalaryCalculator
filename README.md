


<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://https://github.com/raymin92/SalaryCalculator">
    <img src="https://www.google.com/url?sa=i&url=https%3A%2F%2Fflyclipart.com%2Fcalculator-coin-figure-math-money-icon-calculator-icon-png-592506&psig=AOvVaw128RTmOFXsqHWywwgHLB92&ust=1629722417176000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCICwvajTxPICFQAAAAAdAAAAABAM" alt="Logo" width="80" height="80">
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





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
[product-screenshot]: images/screenshot.png
