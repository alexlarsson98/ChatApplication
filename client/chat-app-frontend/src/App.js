import { useEffect, useState } from "react";
import ChannelList from "./ChannelList";

function App() {
  const [currentUser, setCurrentUser] = useState();

  const handleSubmit = () => {
    setCurrentUser("test");
  };
 
  const [channels, setChannels] = useState([
     // Test data
    { id: 1, channelName: "Channel 1" },
    { id: 2, channelName: "Channel 2" },
    { id: 3, channelName: "Channel 3" },
    { id: 4, channelName: "Channel 4" },
  ]);

  useEffect(() => {
    fetch("http://localhost:8001/v1/channels", {mode: 'cors'})
      .then((res) => {
        return res.json();
      })
      .then((data) => {
        console.log(data);
      });
  }, []);

  return (
    <div className="App">
      <input type="text" />
      <button onClick={handleSubmit}>Start chat</button>
      <p>{currentUser}</p>

      <ChannelList channels={channels} />
    </div>
  );
}

export default App;
