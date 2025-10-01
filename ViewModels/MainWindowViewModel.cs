using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_GuitarSongs.Models;

namespace Proyecto_GuitarSongs.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Guitar Song´s";

    [ObservableProperty]
    private Album album = new();

    [ObservableProperty] 
    private Album albumselec = new();
    
    [ObservableProperty]
    private string mensaje = string.Empty;
    
    [ObservableProperty]
    private bool modoCrear = true;
    
    [ObservableProperty]
    private bool modoEditar = false;
    
    [ObservableProperty]
    private ObservableCollection<Album> albunes = new();


    public MainWindowViewModel()
    {
        CargarFormato();
        CargarAlbumes();
    }
    
    // Indicar el tipo de formato del Album
    public List<string> FormatAlbum { set; get; } 
    
    private void CargarFormato()
    {
        FormatAlbum = new List<string>()
        {
            "Vinilo","CD/DVD","Cassette"
        };
    }

    [RelayCommand]
    public void Mostrar_Opc_Avanzadas(object parameter)
    {
        CheckBox opciones = (CheckBox)parameter;
        if (opciones.IsChecked == false)
        {
            Album.formato = "CD/DVD";
        }
    }
    
    // Saber si las opciones avanzadas estan seleccionadas
    [ObservableProperty] 
    private bool avanzado = false;
    
    [RelayCommand]
    public void MostarOpcionAvanzado()
    {
        if (Avanzado == false)
        {
            Avanzado = true;
        }
        else
        {
            Avanzado = false;
        }
    }
    
    // Comprobar que la fecha sea desde hoy a futuro
    private bool CheckDate()
    {
        if (Album.fechaSalida < DateTime.Today)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    // Metodo de crear y comprobar cada elemento
    [RelayCommand]
    public void CrearAlbum(object parameter)
    {
        CheckBox opcion = (CheckBox)parameter;
        if (string.IsNullOrWhiteSpace(Album.titulo))
        {
            Mensaje = "Titulo incorrecto";
        }
        else if (string.IsNullOrWhiteSpace(Album.creador))
        {
            Mensaje = "Creador incorrecto";
        }
        else if (!CheckDate())
        {
            Mensaje = "Fecha incorrecta";
        }
        else if (int.IsNegative(Album.cantidad) || Album.cantidad == 0)
        {
            Mensaje = "Cantidad incorrecta";
        }
        else if (opcion.IsChecked == false)
        {
            Mensaje = "Comprobar Opc.Avanzadas";
        }
        else
        {
            Albunes.Add(Album);
            Mensaje = "Album Creado";
        }
    }

    private void CargarAlbumes()
    {
        Album album = new Album();
        album.titulo = "Back in Black";
        album.creador = "AC/DC";
        album.formato = "Vinilo";
        album.fechaSalida = DateTime.Today;
        Albunes.Add(album);
    }
    
    // Cargar el Album seleccionado y editarlo
    [RelayCommand]
    public void CargarAlbumSelec()
    {
        Album = Albumselec;
        ModoEditar = true;
        ModoCrear = false;
    }
    
    // Cancelar de editar el Album
    [RelayCommand]
    public void CancelarEditar()
    {
        Album = new();
        ModoEditar = false;
        ModoCrear = true;
    }
    
    // Editar el Album seleccionado
    [RelayCommand]
    public void EditarAlbum(object parameter)
    {
        CheckBox opcion = (CheckBox)parameter;
        if (string.IsNullOrWhiteSpace(Album.titulo))
        {
            Mensaje = "Titulo incorrecto";
        }
        else if (string.IsNullOrWhiteSpace(Album.creador))
        {
            Mensaje = "Creador incorrecto";
        }
        else if (!CheckDate())
        {
            Mensaje = "Fecha incorrecta";
        }
        else if (int.IsNegative(Album.cantidad) || Album.cantidad == 0)
        {
            Mensaje = "Cantidad incorrecta";
        }
        else if (opcion.IsChecked == false)
        {
            Mensaje = "Comprobar Opc.Avanzadas";
        }
        else
        {
            Mensaje = "Album Editado";
            ModoCrear = true;
            ModoEditar = false;
        }
    }
    










}