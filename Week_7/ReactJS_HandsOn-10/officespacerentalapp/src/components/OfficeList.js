import React from "react";

const OfficeList = () => {
  const offices = [
    {
      Name: "DBS",
      Rent: 50000,
      Address: "Chennai",
      Image: "https://cdn-klbmd.nitrocdn.com/oflAEolSqrPhKMSrYpDBcfHfpcFckcly/assets/images/optimized/rev-1bcb9bb/www.dbsindia.com/images/locations-pages/chennai.webp",
    },
    {
      Name: "Regus",
      Rent: 65000,
      Address: "Mumbai",
      Image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCmK56MNk4L8n6FT4ivuI36Un_iS7th9lSJg&s",
    },
  ];

  return (
    <div>
      <h1>Office Space, at Affordable Range</h1>

      {offices.map((item, index) => {
        const colorStyle = {
          color: item.Rent < 60000 ? "red" : "green",
        };

        return (
          <div key={index} style={{ marginBottom: "30px" }}>
            <img src={item.Image} width="25%" height="25%" alt="Office Space" />
            <h3>Name: {item.Name}</h3>
            <h3 style={colorStyle}>Rent Rs. {item.Rent}</h3>
            <h3>Address: {item.Address}</h3>
          </div>
        );
      })}
    </div>
  );
};

export default OfficeList;
