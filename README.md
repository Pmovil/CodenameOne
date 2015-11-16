# CodenameOne
Codename One allows Java developers to write their app once and have it work on all mobile devices. 
It features a simulator, designer (visual theme/builder) and ports to multiple OS's all as part of the hierarchy.

You can learn more about Codename One and its capabilities at the [main site](http://www.codenameone.com) and you can read 
additional documentation [here](http://www.codenameone.com/getting-started.html).

# Bytecode translator
This branch is an attempt to generate the needed code for a Windows port, it will use the port from https://github.com/Pmovil/CN1WindowsPort

Please notice it is a work in progress and does not generate all the needed files yet.

You may add the target below to your build file to generate the csharp code:

```
    <target name="bytecode-test-win" depends="clean,copy-windows-override,copy-libs,jar,clean-override">
        <delete dir="build/win"/>
        <echo message="Creating test windows project ..." />
        <echo message="csharp ../CodenameOne/vm/ByteCodeTranslator/tmp;../CodenameOne/vm/JavaAPI/build/classes;../CodenameOne/Ports/Windows/res;../CodenameOne/Ports/Windows/src;../CodenameOne/CodenameOne/build/classes;build/classes build/win ${codename1.mainName} ${codename1.packageName} '${codename1.displayName}' ${codename1.version} universal none" />
        <java jar="../CodenameOne/vm/ByteCodeTranslator/dist/ByteCodeTranslator.jar" fork="true" failonerror="true">
            <jvmarg value="-Xmx2G"/>
            <!-- target type  --> <arg value="csharp"/>
            <!-- class path   --> <arg value="../CodenameOne/vm/ByteCodeTranslator/tmp;../CodenameOne/vm/JavaAPI/build/classes;../CodenameOne/Ports/Windows/res;../CodenameOne/Ports/Windows/src;../CodenameOne/CodenameOne/build/classes;build/classes"/>
            <!-- output path  --> <arg value="build/win"/>
            <!-- main name    --> <arg value="${codename1.mainName}"/>
            <!-- package name --> <arg value="${codename1.packageName}"/>
            <!-- app title    --> <arg value="${codename1.displayName}"/>
            <!-- cn1 version  --> <arg value="${codename1.version}"/>
            <!-- project type --> <arg value="universal"/> <!-- universal, phone, desktop -->
            <!-- extra frameworks --> <arg value="none"/>
        </java>
    </target>
```
