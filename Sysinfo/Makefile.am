
# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = mcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -debug -d:DEBUG
ASSEMBLY = ../bin/Debug/Sysinfo.exe
COMPILE_TARGET = exe
ASSEMBLY_WRAPPER = sysinfo
ASSEMBLY_WRAPPER_IN = sysinfo.in
PROJECT_REFERENCES = 
BUILD_DIR = ../bin/Debug
endif
if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = mcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4
ASSEMBLY = ../bin/Release/Sysinfo.exe
COMPILE_TARGET = exe
ASSEMBLY_WRAPPER = sysinfo
ASSEMBLY_WRAPPER_IN = sysinfo.in
PROJECT_REFERENCES = 
BUILD_DIR = ../bin/Release
endif

	
all: $(ASSEMBLY)

FILES = \
	./Main.cs \
	./AssemblyInfo.cs \
	./CpuInfo.cs \
	./HardwareInfo.cs \
	./MainCairoDrawing.cs \
	./MemoryInfo.cs \
	./PartitionsCairoDrawing.cs \
	./PartitionsInfo.cs \
	./SaveToFile.cs \
	./StorageInfo.cs \
	./SystemInfo.cs \
	./NvidiaInfo.cs 

DATA_FILES = 

RESOURCES = \
	./gui.glade \
	../artwork/amd_logo.png \
	../artwork/debian_logo.png \
	../artwork/fedora_logo.png \
	../artwork/gentoo_logo.png \
	../artwork/graphiccard.png \
	../artwork/intel_logo.png \
	../artwork/mandriva_logo.png \
	../artwork/motherboard.png \
	../artwork/network.png \
	../artwork/no_image.png \
	../artwork/redhat_logo.png \
	../artwork/slackware_logo.png \
	../artwork/soundcard.png \
	../artwork/square_aluminium.png \
	../artwork/square_butter.png \
	../artwork/square_chameleon.png \
	../artwork/square_chokolate.png \
	../artwork/square_orange.png \
	../artwork/square_plum.png \
	../artwork/square_scarletred.png \
	../artwork/square_skyblue.png \
	../artwork/suse_logo.png \
	../artwork/sysinfo_cpu.png \
	../artwork/sysinfo_hardware.png \
	../artwork/sysinfo_logo.png \
	../artwork/sysinfo_memory.png \
	../artwork/sysinfo_other.png \
	../artwork/sysinfo_partitions.png \
	../artwork/sysinfo_storage.png \
	../artwork/sysinfo_system.png \
	../artwork/sysinfo_usb.png \
	../artwork/ubuntu_logo.png \
	../artwork/sysinfo_nvidia.png \
	../artwork/nvidia_logo.png 

EXTRAS = \
	./ChangeLog 

REFERENCES =  \
	-r:System \
	$(GTK_SHARP_20_LIBS) \
	$(GLADE_SHARP_20_LIBS) \
	$(GCONF_SHARP_20_LIBS) \
	$(MONO_CAIRO_LIBS) \
	$(GLIB_SHARP_20_LIBS)

DLL_REFERENCES = 

$(ASSEMBLY) $(ASSEMBLY).mdb: $(build_sources) $(build_resources) $(build_datafiles) 
	mkdir -p $(dir $(ASSEMBLY))		

	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$@ -target:$(COMPILE_TARGET) $(build_sources) $(build_resources_embed) $(build_references_ref)

include $(top_srcdir)/Makefile.include
