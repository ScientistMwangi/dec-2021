import React from "react";

const Footer = () => {
  return (
    <footer className="bg-dark text-white mt-5 p-4 text-center">
      Copyright &copy; {new Date().getFullYear()} NG-eCommerce
    </footer>
  );
}

export default Footer;