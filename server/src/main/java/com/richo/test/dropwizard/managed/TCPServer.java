package com.richo.test.dropwizard.managed;

import com.google.common.primitives.Bytes;
import io.dropwizard.lifecycle.Managed;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.DataInputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class TCPServer implements Managed
{
	private final Logger logger = LoggerFactory.getLogger(getClass());
	private final ExecutorService executor = Executors.newCachedThreadPool();

	@Override
	public void start() throws Exception
	{
		logger.info("{}.{} called", this.getClass().getCanonicalName(), Thread.currentThread().getStackTrace()[1].getMethodName());
		executor.execute(() ->
		{
			try
			{
				final ServerSocket serverSocket = new ServerSocket(1337);
				while (true)
				{
					final Socket socket = serverSocket.accept();
					logger.info("got a connection: {}", socket);
					executor.execute(() ->
					{
						try
						{
							final DataInputStream dataInputStream = new DataInputStream(socket.getInputStream());
							final OutputStream outputStream = socket.getOutputStream();

							List<Byte> buffer = new ArrayList<>();
							while(true)
							{
								buffer.add(dataInputStream.readByte());
								if (buffer.size() > 12)
								{
									final String message = new String(Bytes.toArray(buffer));
									logger.info("Got message: {}", message);
									outputStream.write(message.toUpperCase().getBytes());
									buffer.clear();
								}
							}
						}
						catch (IOException e)
						{
							e.printStackTrace();
						}
					});
				}
			}
			catch (IOException e)
			{
				e.printStackTrace();
			}
		});
	}

	@Override
	public void stop() throws Exception
	{
		logger.info("{}.{} called", this.getClass().getCanonicalName(), Thread.currentThread().getStackTrace()[1].getMethodName());
	}
}
