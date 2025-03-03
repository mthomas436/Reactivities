import { Typography, List, ListItem, ListItemText } from "@mui/material";
import { useEffect, useState } from "react";

function App() {
  const title = "Welcome to Reactivities";
  const [activities, setActivities] = useState<Activity>([]);

  useEffect(() => {
    fetch("http://localhost:5000/api/activities")
      .then((response) => response.json())
      .then((data) => setActivities(data));

    console.log(activities);
  }, []);

  return (
    <>
      <Typography variant="h3">{title}</Typography>
      <List>
        {" "}
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  );
}

export default App;
