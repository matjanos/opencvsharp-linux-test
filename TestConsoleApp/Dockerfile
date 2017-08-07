FROM charlielito/python-opencv-contrib

MAINTAINER Jakub Matjanowski "kuba@matjanowski.pl"

RUN cat /etc/issue
RUN apt-get update
RUN apt-get install -y apt-transport-https wget


#install cmake 3.2
RUN apt-get remove cmake -y
RUN wget http://www.cmake.org/files/v3.2/cmake-3.2.2.tar.gz
RUN tar xf cmake-3.2.2.tar.gz
RUN ls
WORKDIR cmake-3.2.2
RUN ./configure
RUN make
RUN make install
RUN export PATH=/usr/local/bin:$PATH
RUN export LD_LIBRARY_PATH=/usr/local/lib:$LD_LIBRARY_PATH


# get opencvsharp 
WORKDIR /tmp/
RUN git clone --branch 3.2.0.20170126 https://github.com/shimat/opencvsharp.git opencvsharp
RUN mkdir /tmp/opencvsharp/src/OpenCvSharpExtern/build
WORKDIR /tmp/opencvsharp/src/OpenCvSharpExtern/build
RUN cmake ..
RUN make
RUN make install

#get dotnet core
#RUN sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
#RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
#RUN apt-get update
#RUN sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
#RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
#RUN apt-get update
#RUN apt-get install dotnet-dev-1.0.4 -y

#get mono
RUN apt install --reinstall gnupg2
RUN apt install dirmngr
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
RUN echo "deb http://download.mono-project.com/repo/ubuntu trusty main" | sudo tee /etc/apt/sources.list.d/mono-official.list
RUN apt-get update
RUN apt-get install mono-devel -y

ARG source
WORKDIR /app
RUN ls
COPY ${source:-bin/Docker/publish} .
ENTRYPOINT ["MONO_LOG_LEVEL=debug mono", "TestConsoleApp.dll"]
