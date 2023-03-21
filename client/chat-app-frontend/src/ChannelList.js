const ChannelList = ({ channels }) => {
  return (
    <div className="channel-list">
      {channels.map((channel) => (
        <div className="list-channels" key={channel.id}>
          <h2>{channel.channelName}</h2>
        </div>
      ))}
    </div>
  );
};

export default ChannelList;
