using Api.Model.Modelos;
using Api.Model.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Context
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options)
        {
          
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  base.OnModelCreating(modelBuilder);
            //Regster store procedure custom object. 

            base.OnModelCreating(modelBuilder);
            //Regster store procedure custom object. 

           
            //aqui le indico la ARTICULO_PRECIO despues le indico la tabla y por ultimo el esquema
            modelBuilder.Entity<ARTICULO_PRECIO>().ToTable("ARTICULO_PRECIO", schema: "TIENDA");
            modelBuilder.Entity<ARTICULOS>().ToTable("ARTICULO", schema: "TIENDA");
            /*En la base de datos esta tabla llama vendedor, pero se refiere a la bodega*/
            modelBuilder.Entity<BODEGA>().ToTable("VENDEDOR", schema: "TIENDA");
            modelBuilder.Entity<CIERRE_CAJA>().ToTable("CIERRE_CAJA", schema: "TIENDA");
            modelBuilder.Entity<CLIENTES>().ToTable("CLIENTE", schema: "TIENDA");
            modelBuilder.Entity<CONSEC_CAJA_POS>().ToTable("CONSEC_CAJA_POS", schema: "TIENDA");
            modelBuilder.Entity<CONSECUTIVO_FA>().ToTable("CONSECUTIVO_FA", schema: "TIENDA");
            modelBuilder.Entity<CONSECUTIVOS>().ToTable("CONSECUTIVO", schema: "TIENDA");
            modelBuilder.Entity<EXISTENCIA_BODEGA>().ToTable("EXISTENCIA_BODEGA", schema: "TIENDA");
            modelBuilder.Entity<FACTURA_LINEA>().ToTable("FACTURA_LINEA", schema: "TIENDA");
            modelBuilder.Entity<Facturas>().ToTable("FACTURA", schema: "TIENDA");
            modelBuilder.Entity<FORMA_PAGOS>().ToTable("FORMA_PAGO", schema: "TIENDA");
            modelBuilder.Entity<MONEDA_HIST>().ToTable("MONEDA_HIST", schema: "TIENDA");
            modelBuilder.Entity<TIPO_TARJETAS>().ToTable("TIPO_TARJETA", schema: "TIENDA");
            modelBuilder.Entity<CONDICION_PAGO>().ToTable("CONDICION_PAGO", schema: "TIENDA");
            modelBuilder.Entity<FacturaTemporal>().ToTable("FacturaTemporal", schema: "dbo");
            modelBuilder.Entity<Usuarios>().ToTable("USUARIO", schema: "ERPADMIN");
            modelBuilder.Entity<RolesUsuarios>().ToTable("RolesUsuarios", schema: "dbo");
            modelBuilder.Entity<Roles>().ToTable("Roles", schema: "dbo");
            modelBuilder.Entity<Funciones>().ToTable("Funciones", schema: "dbo");
            modelBuilder.Entity<FuncionesRoles>().ToTable("FuncionesRoles", schema: "dbo");
            modelBuilder.Entity<Grupos>().ToTable("GRUPO", schema: "TIENDA");
            modelBuilder.Entity<Grupo_Caja>().ToTable("GRUPO_CAJA", schema: "TIENDA");


            //aqui le indico que la tabla ARTICULO_PRECIO su llave es el campo ARTICULO
            modelBuilder.Entity<ARTICULO_PRECIO>().HasKey(ap => new { ap.NIVEL_PRECIO, ap.MONEDA, ap.VERSION, ap.ARTICULO, ap.VERSION_ARTICULO });
            //aqui le indico que la tabla ARTICULO su llave es el campo ARTICULO
            modelBuilder.Entity<ARTICULOS>().HasKey(a => a.Articulo);
            /*En la base de datos esta tabla llama vendedor, pero se refiere a la bodega*/
            modelBuilder.Entity<BODEGA>().HasKey(b => b.Vendedor);
            modelBuilder.Entity<CIERRE_CAJA>().HasKey(cc => new { cc.Num_Cierre_Caja, cc.Caja });
            modelBuilder.Entity<CLIENTES>().HasKey(c => c.Cliente);
            modelBuilder.Entity<CONSEC_CAJA_POS>().HasKey(ccp => new { ccp.Codigo, ccp.Caja });
            modelBuilder.Entity<CONSECUTIVO_FA>().HasKey(cf => cf.CODIGO_CONSECUTIVO);
            modelBuilder.Entity<CONSECUTIVOS>().HasKey(c => c.CONSECUTIVO);
            modelBuilder.Entity<EXISTENCIA_BODEGA>().HasKey(eb => new { eb.ARTICULO, eb.BODEGA });
            modelBuilder.Entity<FACTURA_LINEA>().HasKey(fl => new { fl.Factura, fl.Tipo_Documento, fl.Linea });
            modelBuilder.Entity<Facturas>().HasKey(f => new { f.Tipo_Documento, f.Factura });
            modelBuilder.Entity<FORMA_PAGOS>().HasKey(fp => fp.Forma_Pago);
            modelBuilder.Entity<MONEDA_HIST>().HasKey(mh => new { mh.Moneda, mh.Fecha });
            modelBuilder.Entity<TIPO_TARJETAS>().HasKey(tt => tt.Tipo_Tarjeta);
            modelBuilder.Entity<FacturaTemporal>().HasKey(ft => new { ft.Factura, ft.ArticuloID });
            modelBuilder.Entity<CONDICION_PAGO>().HasKey(cp => cp.Condicion_Pago);
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Usuario);
            modelBuilder.Entity<RolesUsuarios>().HasKey(ru => new { ru.RolID, ru.UsuarioID });
            modelBuilder.Entity<Roles>().HasKey(r => r.RolID);
            modelBuilder.Entity<Funciones>().HasKey(f => f.FuncionID);
            modelBuilder.Entity<FuncionesRoles>().HasKey(fr => new { fr.FuncionID, fr.RolID } );
            modelBuilder.Entity<Grupos>().HasKey(grp => grp.Grupo);
            modelBuilder.Entity<Grupo_Caja>().HasKey(gc => new { gc.Grupo, gc.Caja });

            //vista
            //modelBuilder.Entity<Blog>().ToView("blogsView", schema: "blogging");
            modelBuilder.Entity<ViewArticulo>().ToView("ViewArticulo", schema: "dbo");
            //modelBuilder.Entity<ViewArticulo>().HasKey("ViewArticulo", schema: "dbo");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //Estoy utilizando Entity Core
        ////aqui se le esta indicando que tiene 2 llave la tabla oportunidad
        //modelBuilder.Entity<Oportunidad>()
        //	.HasKey(c => new { c.OportunidadID, c.ClienteID });

        /*
        modelBuilder.Entity<Pmf>()
        .HasKey(c => new { c.PmfID, c.ModeloID });*/

        // Here you can put FluentAPI code or add configuration map's
        /*
        modelBuilder.Entity<ApplicationUser>(b =>
        {
            b.ToTable("AspNetUser");
            b.Property(u => u.Id).HasColumnName("UserId");
            //b.Property(u => u.UserName ).HasColumnName("LoginName");
            b.Property(u => u.UserName).HasMaxLength(70);
            b.Property(u => u.NormalizedUserName).HasMaxLength(70);
            b.Property(u => u.Email).HasMaxLength(70);
            b.Property(u => u.NormalizedEmail).HasMaxLength(70);
        });

        modelBuilder.Entity<IdentityUserClaim<int>>(b =>
        {
            b.ToTable("AspNetUserClaim");
            b.Property(uc => uc.Id).HasColumnName("UserClaimId");
        });

        modelBuilder.Entity<IdentityUserLogin<int>>(b =>
        {
            b.ToTable("AspNetUserLogin");
        });

        modelBuilder.Entity<IdentityUserToken<int>>(b =>
        {
            b.ToTable("AspNetUserToken");

        });

        modelBuilder.Entity<ApplicationRole>(b =>
        {
            b.ToTable("AspNetRole");
            b.Property(r => r.Id).HasColumnName("RoleId");
        });

        modelBuilder.Entity<IdentityRoleClaim<int>>(b =>
        {
            b.ToTable("AspNetRoleClaim");
            b.Property(rc => rc.Id).HasColumnName("RoleClaimId");
        });

        modelBuilder.Entity<IdentityUserRole<int>>(b =>
        {
            b.ToTable("AspNetUserRole");
        });

        modelBuilder.Entity<Sucursal>().HasKey(c => new { c.SucursalID });
        */
        //}





        //public virtual DbSet<ACC_PER_IMPRESION> ACC_PER_IMPRESION { get; set; }
        //public virtual DbSet<ACTIVIDAD_COMERCIAL> ACTIVIDAD_COMERCIAL { get; set; }
        //public virtual DbSet<ACTIVO_ACCION> ACTIVO_ACCION { get; set; }
        //public virtual DbSet<ACTIVO_CENTRO> ACTIVO_CENTRO { get; set; }
        //public virtual DbSet<ACTIVO_DESMANTELAMIENTO> ACTIVO_DESMANTELAMIENTO { get; set; }
        //public virtual DbSet<ACTIVO_FIJO> ACTIVO_FIJO { get; set; }
        //public virtual DbSet<ACTIVO_HIST_MANT> ACTIVO_HIST_MANT { get; set; }
        //public virtual DbSet<ACTIVO_HIST_REVAL> ACTIVO_HIST_REVAL { get; set; }
        //public virtual DbSet<ACTIVO_MEJORA> ACTIVO_MEJORA { get; set; }
        //public virtual DbSet<ADICIONAL> ADICIONAL { get; set; }
        //public virtual DbSet<ADICIONAL_NOMINA> ADICIONAL_NOMINA { get; set; }
        //public virtual DbSet<ADICIONAL_NOMINA_VALOR> ADICIONAL_NOMINA_VALOR { get; set; }
        //public virtual DbSet<ADICIONAL_VALOR> ADICIONAL_VALOR { get; set; }
        //public virtual DbSet<ADICIONALEMPLEADO> ADICIONALEMPLEADO { get; set; }
        //public virtual DbSet<ADICIONALNOMINA> ADICIONALNOMINA { get; set; }
        //public virtual DbSet<ADMIN_COTIZANTE> ADMIN_COTIZANTE { get; set; }
        //public virtual DbSet<ADMINISTRADORA> ADMINISTRADORA { get; set; }
        //public virtual DbSet<ADUANA> ADUANA { get; set; }
        //public virtual DbSet<AFILIADO> AFILIADO { get; set; }
        //public virtual DbSet<AGENTE_ADUANAL> AGENTE_ADUANAL { get; set; }
        //public virtual DbSet<AJUSTE_CONFIG> AJUSTE_CONFIG { get; set; }
        //public virtual DbSet<AJUSTE_SUBSUBTIPO> AJUSTE_SUBSUBTIPO { get; set; }
        //public virtual DbSet<AJUSTE_SUBTIPO> AJUSTE_SUBTIPO { get; set; }
        //public virtual DbSet<ALIAS_PRODUCCION> ALIAS_PRODUCCION { get; set; }
        //public virtual DbSet<ANTICIPO_MARCA_FACT> ANTICIPO_MARCA_FACT { get; set; }
        //public virtual DbSet<APERTURA_CAJA> APERTURA_CAJA { get; set; }
        //public virtual DbSet<APROBACION> APROBACION { get; set; }
        //public virtual DbSet<ARANCEL_IMPUESTO> ARANCEL_IMPUESTO { get; set; }
        //public virtual DbSet<ART_UND_DISTRIBUCI> ART_UND_DISTRIBUCI { get; set; }
        public virtual DbSet<ARTICULOS> ARTICULOS { get; set; }
        //public virtual DbSet<ARTICULO_ALTERNO> ARTICULO_ALTERNO { get; set; }
        //public virtual DbSet<ARTICULO_COLOR> ARTICULO_COLOR { get; set; }
        //public virtual DbSet<ARTICULO_COMPRA> ARTICULO_COMPRA { get; set; }
        //public virtual DbSet<ARTICULO_CUENTA> ARTICULO_CUENTA { get; set; }
        //public virtual DbSet<ARTICULO_ENSAMBLE> ARTICULO_ENSAMBLE { get; set; }
        //public virtual DbSet<ARTICULO_ESPE> ARTICULO_ESPE { get; set; }
        //public virtual DbSet<ARTICULO_ESTILO> ARTICULO_ESTILO { get; set; }
        //public virtual DbSet<ARTICULO_FOTO> ARTICULO_FOTO { get; set; }
        //public virtual DbSet<ARTICULO_FOTO_AD> ARTICULO_FOTO_AD { get; set; }
        public virtual DbSet<ARTICULO_PRECIO> ARTICULO_PRECIO { get; set; }
        //public virtual DbSet<ARTICULO_PROVEEDOR> ARTICULO_PROVEEDOR { get; set; }
        //public virtual DbSet<ARTICULO_SERIE_POS> ARTICULO_SERIE_POS { get; set; }
        //public virtual DbSet<ARTICULO_TALLA> ARTICULO_TALLA { get; set; }
        //public virtual DbSet<ASIENTO_DE_DIARIO> ASIENTO_DE_DIARIO { get; set; }
        //public virtual DbSet<ASIENTO_DIST_LINEA> ASIENTO_DIST_LINEA { get; set; }
        //public virtual DbSet<ASIENTO_DISTRIBUID> ASIENTO_DISTRIBUID { get; set; }
        //public virtual DbSet<ASIENTO_MARCADO> ASIENTO_MARCADO { get; set; }
        //public virtual DbSet<ASIENTO_MAYORIZADO> ASIENTO_MAYORIZADO { get; set; }
        //public virtual DbSet<ASIENTO_MOV_PRES> ASIENTO_MOV_PRES { get; set; }
        //public virtual DbSet<ASIENTO_RECU_LINEA> ASIENTO_RECU_LINEA { get; set; }
        //public virtual DbSet<ASIENTO_RECURRENTE> ASIENTO_RECURRENTE { get; set; }
        //public virtual DbSet<ASIENTOS_CHEQUE> ASIENTOS_CHEQUE { get; set; }
        //public virtual DbSet<ASIENTOS_DOC_POS> ASIENTOS_DOC_POS { get; set; }
        //public virtual DbSet<ASOC_HERRAM> ASOC_HERRAM { get; set; }
        //public virtual DbSet<ATRIB_EQUIPO> ATRIB_EQUIPO { get; set; }
        //public virtual DbSet<ATRIBUTO> ATRIBUTO { get; set; }
        //public virtual DbSet<ATRIBUTO_VALOR> ATRIBUTO_VALOR { get; set; }
        //public virtual DbSet<AUDIT_CUPON> AUDIT_CUPON { get; set; }
        //public virtual DbSet<AUDIT_TRANS_INV> AUDIT_TRANS_INV { get; set; }
        //public virtual DbSet<AUDIT_TRANS_MANT> AUDIT_TRANS_MANT { get; set; }
        //public virtual DbSet<AUDITORIA_MODIFICACION> AUDITORIA_MODIFICACION { get; set; }
        //public virtual DbSet<AUTOR_COMPRA> AUTOR_COMPRA { get; set; }
        //public virtual DbSet<AUTOR_VENTA> AUTOR_VENTA { get; set; }
        //public virtual DbSet<AUXILIAR_ANTICIPO_FAC> AUXILIAR_ANTICIPO_FAC { get; set; }
        //public virtual DbSet<AUXILIAR_CC> AUXILIAR_CC { get; set; }
        //public virtual DbSet<AUXILIAR_CP> AUXILIAR_CP { get; set; }
        //public virtual DbSet<AUXILIAR_PARC_CC> AUXILIAR_PARC_CC { get; set; }
        //public virtual DbSet<AUXILIAR_PARC_CP> AUXILIAR_PARC_CP { get; set; }
        //public virtual DbSet<AUXILIAR_POS> AUXILIAR_POS { get; set; }
        //public virtual DbSet<BENEFICIOS_ANTIGUE> BENEFICIOS_ANTIGUE { get; set; }
        //public virtual DbSet<BITACORA_FE> BITACORA_FE { get; set; }
        //public virtual DbSet<BLOQUEO_IMPRESO> BLOQUEO_IMPRESO { get; set; }
        //public virtual DbSet<BOD_CARGA_MANUF> BOD_CARGA_MANUF { get; set; }
        public virtual DbSet<BODEGA> BODEGAS { get; set; }
        //public virtual DbSet<BODEGA_ENCARGADO> BODEGA_ENCARGADO { get; set; }
        //public virtual DbSet<BOLETA_DESPACHO_AD> BOLETA_DESPACHO_AD { get; set; }
        //public virtual DbSet<BOLETA_INV_FISICO> BOLETA_INV_FISICO { get; set; }
        //public virtual DbSet<BONIF_ART_X_CLI> BONIF_ART_X_CLI { get; set; }
        //public virtual DbSet<BONIF_CLAS_X_CLI> BONIF_CLAS_X_CLI { get; set; }
        //public virtual DbSet<BONO_CATEGORIA> BONO_CATEGORIA { get; set; }
        //public virtual DbSet<BONO_PAGO> BONO_PAGO { get; set; }
        //public virtual DbSet<BONO_TIENDA> BONO_TIENDA { get; set; }
        //public virtual DbSet<CADENA> CADENA { get; set; }
        //public virtual DbSet<CAJA> CAJA { get; set; }
        //public virtual DbSet<CAJA_BANCO> CAJA_BANCO { get; set; }
        //public virtual DbSet<CAJA_CHICA> CAJA_CHICA { get; set; }
        //public virtual DbSet<CAJA_POS> CAJA_POS { get; set; }
        //public virtual DbSet<CAJERO> CAJERO { get; set; }
        //public virtual DbSet<CALC_VAC_DETALLE> CALC_VAC_DETALLE { get; set; }
        //public virtual DbSet<CALCULO_FLUJO_CAJA> CALCULO_FLUJO_CAJA { get; set; }
        //public virtual DbSet<CALCULO_VACACIONAL> CALCULO_VACACIONAL { get; set; }
        //public virtual DbSet<CALENDARIO> CALENDARIO { get; set; }
        //public virtual DbSet<CALENDARIO_ANO> CALENDARIO_ANO { get; set; }
        //public virtual DbSet<CALENDARIO_DET> CALENDARIO_DET { get; set; }
        //public virtual DbSet<CANCELACION_COTIZACIONES> CANCELACION_COTIZACIONES { get; set; }
        //public virtual DbSet<CARGOS> CARGOS { get; set; }
        //public virtual DbSet<CAT_PUESTO_EXTERNO> CAT_PUESTO_EXTERNO { get; set; }
        //public virtual DbSet<CATALOGO_EXISTENCIA> CATALOGO_EXISTENCIA { get; set; }
        //public virtual DbSet<CATALOGO_SUIRPLUS> CATALOGO_SUIRPLUS { get; set; }
        //public virtual DbSet<CATEGORIA_CLIENTE> CATEGORIA_CLIENTE { get; set; }
        //public virtual DbSet<CATEGORIA_PROVEED> CATEGORIA_PROVEED { get; set; }
        //public virtual DbSet<CENTRO_CONCEPTO> CENTRO_CONCEPTO { get; set; }
        //public virtual DbSet<CENTRO_COSTO> CENTRO_COSTO { get; set; }
        //public virtual DbSet<CENTRO_COSTO_CR> CENTRO_COSTO_CR { get; set; }
        //public virtual DbSet<CENTRO_CUENTA> CENTRO_CUENTA { get; set; }
        //public virtual DbSet<CENTRO_PARTIDA> CENTRO_PARTIDA { get; set; }
        //public virtual DbSet<CENTRO_TRABAJO> CENTRO_TRABAJO { get; set; }
        //public virtual DbSet<CG_AUX> CG_AUX { get; set; }
        //public virtual DbSet<CHEQUE> CHEQUE { get; set; }
        //public virtual DbSet<CHEQUES_RUBROS_CF> CHEQUES_RUBROS_CF { get; set; }
        public virtual DbSet<CIERRE_CAJA> CIERRE_CAJA { get; set; }
        //public virtual DbSet<CIERRE_DESG_TARJ> CIERRE_DESG_TARJ { get; set; }
        //public virtual DbSet<CIERRE_DET_PAGO> CIERRE_DET_PAGO { get; set; }
        //public virtual DbSet<CIERRE_INFO_TARJ> CIERRE_INFO_TARJ { get; set; }
        //public virtual DbSet<CIERRE_POS> CIERRE_POS { get; set; }
        //public virtual DbSet<CIERRE_TIENDA> CIERRE_TIENDA { get; set; }
        //public virtual DbSet<CLASE_DOC_POS> CLASE_DOC_POS { get; set; }
        //public virtual DbSet<CLASE_EQUIPO> CLASE_EQUIPO { get; set; }
        //public virtual DbSet<CLASE_SEGURO> CLASE_SEGURO { get; set; }
        //public virtual DbSet<CLASIFIC_ADI_ARTICULO> CLASIFIC_ADI_ARTICULO { get; set; }
        //public virtual DbSet<CLASIFICACION> CLASIFICACION { get; set; }
        //public virtual DbSet<CLASIFICACION_ADI> CLASIFICACION_ADI { get; set; }
        //public virtual DbSet<CLASIFICACION_ADI_VALOR> CLASIFICACION_ADI_VALOR { get; set; }
        //public virtual DbSet<CLASIFICACION_COMPRA> CLASIFICACION_COMPRA { get; set; }
        //public virtual DbSet<CLASIFICACION_VENTA> CLASIFICACION_VENTA { get; set; }
        public virtual DbSet<CLIENTES> CLIENTES { get; set; }
        //public virtual DbSet<CLIENTE_EXPR_ENTR> CLIENTE_EXPR_ENTR { get; set; }
        //public virtual DbSet<CLIENTE_EXPRESS> CLIENTE_EXPRESS { get; set; }
        //public virtual DbSet<CLIENTE_FORMA_PAGO> CLIENTE_FORMA_PAGO { get; set; }
        //public virtual DbSet<CLIENTE_POS> CLIENTE_POS { get; set; }
        //public virtual DbSet<CLIENTE_RETENCION> CLIENTE_RETENCION { get; set; }
        //public virtual DbSet<CLIENTE_VENDEDOR> CLIENTE_VENDEDOR { get; set; }
        //public virtual DbSet<COBRADOR> COBRADOR { get; set; }
        //public virtual DbSet<COBRO_POS> COBRO_POS { get; set; }
        //public virtual DbSet<COD_INGRESO> COD_INGRESO { get; set; }
        //public virtual DbSet<CODIGO_ARANCEL> CODIGO_ARANCEL { get; set; }
        //public virtual DbSet<CODIGO_POSTAL> CODIGO_POSTAL { get; set; }
        //public virtual DbSet<CODING_CARTA_RENTA> CODING_CARTA_RENTA { get; set; }
        //public virtual DbSet<COMISION_ARTICULO> COMISION_ARTICULO { get; set; }
        //public virtual DbSet<COMISION_EXCEPCION> COMISION_EXCEPCION { get; set; }
        //public virtual DbSet<CONC_FORM_CONCEPTO> CONC_FORM_CONCEPTO { get; set; }
        //public virtual DbSet<CONC_FORM_RUBRO> CONC_FORM_RUBRO { get; set; }
        //public virtual DbSet<CONCEPTO> CONCEPTO { get; set; }
        //public virtual DbSet<CONCEPTO_FLUJO> CONCEPTO_FLUJO { get; set; }
        //public virtual DbSet<CONCEPTO_FORMULA> CONCEPTO_FORMULA { get; set; }
        //public virtual DbSet<CONCEPTO_LIQUIDAC> CONCEPTO_LIQUIDAC { get; set; }
        //public virtual DbSet<CONCEPTO_PUESTO> CONCEPTO_PUESTO { get; set; }
        //public virtual DbSet<CONCEPTO_USUARIO> CONCEPTO_USUARIO { get; set; }
        //public virtual DbSet<CONCEPTO_VALE> CONCEPTO_VALE { get; set; }
        //public virtual DbSet<CONCILIACION> CONCILIACION { get; set; }
        public virtual DbSet<CONDICION_PAGO> CONDICION_PAGO { get; set; }
        //public virtual DbSet<CONEXION> CONEXION { get; set; }
        //public virtual DbSet<CONFIG_CAJA> CONFIG_CAJA { get; set; }
        //public virtual DbSet<CONFIG_CLIENTE> CONFIG_CLIENTE { get; set; }
        //public virtual DbSet<CONFIG_ENVIOS> CONFIG_ENVIOS { get; set; }
        //public virtual DbSet<CONFIG_TARJETAS> CONFIG_TARJETAS { get; set; }
        //public virtual DbSet<CONSE_NCF_RETENCION> CONSE_NCF_RETENCION { get; set; }
        //public virtual DbSet<CONSEC_AJUSTE_CONF> CONSEC_AJUSTE_CONF { get; set; }
        public virtual DbSet<CONSEC_CAJA_POS> CONSEC_CAJA_POS { get; set; }
        //public virtual DbSet<CONSEC_USUARIO> CONSEC_USUARIO { get; set; }
        //public virtual DbSet<CONSECUFA_USUARIO> CONSECUFA_USUARIO { get; set; }
        public virtual DbSet<CONSECUTIVOS> CONSECUTIVOS { get; set; }
        //public virtual DbSet<CONSECUTIVO_CI> CONSECUTIVO_CI { get; set; }
        //public virtual DbSet<CONSECUTIVO_FA> CONSECUTIVO_FA { get; set; }
        //public virtual DbSet<CONSECUTIVO_USUARIO> CONSECUTIVO_USUARIO { get; set; }
        //public virtual DbSet<CONSTANTE_CALC_VALOR> CONSTANTE_CALC_VALOR { get; set; }
        //public virtual DbSet<CONSTANTE_CALCULO> CONSTANTE_CALCULO { get; set; }
        //public virtual DbSet<CONTACTO_CLIENTE> CONTACTO_CLIENTE { get; set; }
        //public virtual DbSet<CONTACTOS> CONTACTOS { get; set; }
        //public virtual DbSet<CONTRAREC_ASIENTO_CR> CONTRAREC_ASIENTO_CR { get; set; }
        //public virtual DbSet<CONTRAREC_MOV_PRES> CONTRAREC_MOV_PRES { get; set; }
        //public virtual DbSet<CONTRARECIBOS> CONTRARECIBOS { get; set; }
        //public virtual DbSet<CONTRARECIBOS_CC> CONTRARECIBOS_CC { get; set; }
        //public virtual DbSet<CONTRIB_VAC_CONDIC> CONTRIB_VAC_CONDIC { get; set; }
        //public virtual DbSet<CONTRIB_VAC_FORM> CONTRIB_VAC_FORM { get; set; }
        //public virtual DbSet<CONTRIBUCION_VAC> CONTRIBUCION_VAC { get; set; }
        //public virtual DbSet<CONTROL_HORAS_INCAP> CONTROL_HORAS_INCAP { get; set; }
        //public virtual DbSet<CORRIDA_AD> CORRIDA_AD { get; set; }
        //public virtual DbSet<COST_STD_BATCH> COST_STD_BATCH { get; set; }
        //public virtual DbSet<COSTO_STD_DESGL> COSTO_STD_DESGL { get; set; }
        //public virtual DbSet<COSTO_UEPS_PEPS> COSTO_UEPS_PEPS { get; set; }
        //public virtual DbSet<COTIZANTE> COTIZANTE { get; set; }
        //public virtual DbSet<CP_DET_RETENCION_PAR> CP_DET_RETENCION_PAR { get; set; }
        //public virtual DbSet<CREDITO_EMPLEADO> CREDITO_EMPLEADO { get; set; }
        //public virtual DbSet<CS_ACOMPANANTE> CS_ACOMPANANTE { get; set; }
        //public virtual DbSet<CS_BITACORA_VISITA> CS_BITACORA_VISITA { get; set; }
        //public virtual DbSet<CS_CUOTAS> CS_CUOTAS { get; set; }
        //public virtual DbSet<CS_CUOTAS_OPCIONDOS> CS_CUOTAS_OPCIONDOS { get; set; }
        //public virtual DbSet<CS_FIADOR> CS_FIADOR { get; set; }
        //public virtual DbSet<CS_LOG> CS_LOG { get; set; }
        //public virtual DbSet<CS_LOG_OPCIONDOS> CS_LOG_OPCIONDOS { get; set; }
        //public virtual DbSet<CS_PLANILLA_COBRO> CS_PLANILLA_COBRO { get; set; }
        //public virtual DbSet<CS_PLANILLA_COBRO_OPCIONDOS> CS_PLANILLA_COBRO_OPCIONDOS { get; set; }
        //public virtual DbSet<CS_PORCENT_ESQUELA> CS_PORCENT_ESQUELA { get; set; }
        //public virtual DbSet<CS_PROCEDENCIA_CORTE> CS_PROCEDENCIA_CORTE { get; set; }
        //public virtual DbSet<CS_RECIBIDO> CS_RECIBIDO { get; set; }
        //public virtual DbSet<CS_RECIBIDO_DETALLE> CS_RECIBIDO_DETALLE { get; set; }
        //public virtual DbSet<CS_RECIBIDO_DETALLE_OPCIONDOS> CS_RECIBIDO_DETALLE_OPCIONDOS { get; set; }
        //public virtual DbSet<CS_RECIBIDO_OPCIONDOS> CS_RECIBIDO_OPCIONDOS { get; set; }
        //public virtual DbSet<CTA_AJUSTE_INFL> CTA_AJUSTE_INFL { get; set; }
        //public virtual DbSet<CUADRE_AUX> CUADRE_AUX { get; set; }
        //public virtual DbSet<CUADRE_CONTA> CUADRE_CONTA { get; set; }
        //public virtual DbSet<CUADRES_CG> CUADRES_CG { get; set; }
        //public virtual DbSet<CUBO_PRIVILEGIO> CUBO_PRIVILEGIO { get; set; }
        //public virtual DbSet<CUENTA_BANCARIA> CUENTA_BANCARIA { get; set; }
        //public virtual DbSet<CUENTA_CONTABLE> CUENTA_CONTABLE { get; set; }
        //public virtual DbSet<CUENTA_DEPRECIACIO> CUENTA_DEPRECIACIO { get; set; }
        //public virtual DbSet<CUENTA_SECCION> CUENTA_SECCION { get; set; }
        //public virtual DbSet<CUPON> CUPON { get; set; }
        //public virtual DbSet<DCTO_ART_X_CLI> DCTO_ART_X_CLI { get; set; }
        //public virtual DbSet<DCTO_CLAS_X_CLI> DCTO_CLAS_X_CLI { get; set; }
        //public virtual DbSet<DEFINICION_PIVOTE_BI> DEFINICION_PIVOTE_BI { get; set; }
        //public virtual DbSet<DENOMINACION> DENOMINACION { get; set; }
        //public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        //public virtual DbSet<DEPOSITO_POS> DEPOSITO_POS { get; set; }
        //public virtual DbSet<DEPR_CENTRO_COSTO> DEPR_CENTRO_COSTO { get; set; }
        //public virtual DbSet<DEPR_PORCENTAJE> DEPR_PORCENTAJE { get; set; }
        //public virtual DbSet<DES_BON_ESCALA_BONIFICACION> DES_BON_ESCALA_BONIFICACION { get; set; }
        //public virtual DbSet<DES_BON_ESPECIFICACION_GRUPO> DES_BON_ESPECIFICACION_GRUPO { get; set; }
        //public virtual DbSet<DES_BON_PAQUETE> DES_BON_PAQUETE { get; set; }
        //public virtual DbSet<DES_BON_PAQUETE_REGLA> DES_BON_PAQUETE_REGLA { get; set; }
        //public virtual DbSet<DES_BON_PAQUETE_RUTA> DES_BON_PAQUETE_RUTA { get; set; }
        //public virtual DbSet<DES_BON_PAQUETE_TIENDA> DES_BON_PAQUETE_TIENDA { get; set; }
        //public virtual DbSet<DES_BON_REGLA> DES_BON_REGLA { get; set; }
        //public virtual DbSet<DES_BON_REGLA_LOTE> DES_BON_REGLA_LOTE { get; set; }
        //public virtual DbSet<DESC_PRONTO_PAGO> DESC_PRONTO_PAGO { get; set; }
        //public virtual DbSet<DESG_IMPUESTO_CH> DESG_IMPUESTO_CH { get; set; }
        //public virtual DbSet<DESGLOSE_ART_TMP> DESGLOSE_ART_TMP { get; set; }
        //public virtual DbSet<DESGLOSE_PRESUP> DESGLOSE_PRESUP { get; set; }
        //public virtual DbSet<DESPACHO> DESPACHO { get; set; }
        //public virtual DbSet<DESPACHO_DETALLE> DESPACHO_DETALLE { get; set; }
        //public virtual DbSet<DESTINO> DESTINO { get; set; }
        //public virtual DbSet<DET_DOCUMENTO_EMBARQUE> DET_DOCUMENTO_EMBARQUE { get; set; }
        //public virtual DbSet<DET_DOCUMENTO_ORDEN> DET_DOCUMENTO_ORDEN { get; set; }
        //public virtual DbSet<DET_LIN_EMBARQUE> DET_LIN_EMBARQUE { get; set; }
        //public virtual DbSet<DET_MOD_RETENCION> DET_MOD_RETENCION { get; set; }
        //public virtual DbSet<DET_MOV_APLICADO> DET_MOV_APLICADO { get; set; }
        //public virtual DbSet<DET_MOV_NOAPLICADO> DET_MOV_NOAPLICADO { get; set; }
        //public virtual DbSet<DET_REG_BILLETE> DET_REG_BILLETE { get; set; }
        //public virtual DbSet<DET_RETENCION_CH> DET_RETENCION_CH { get; set; }
        //public virtual DbSet<DET_SOLICITUD_AF_NOTIF> DET_SOLICITUD_AF_NOTIF { get; set; }
        //public virtual DbSet<DET_TIPOSERVICIO_CB> DET_TIPOSERVICIO_CB { get; set; }
        //public virtual DbSet<DET_TIPOSERVICIO_CC> DET_TIPOSERVICIO_CC { get; set; }
        //public virtual DbSet<DET_TIPOSERVICIO_CP> DET_TIPOSERVICIO_CP { get; set; }
        //public virtual DbSet<DET_TRANS_CB> DET_TRANS_CB { get; set; }
        //public virtual DbSet<DETALLE_CORRIDA> DETALLE_CORRIDA { get; set; }
        //public virtual DbSet<DETALLE_DIRECCION> DETALLE_DIRECCION { get; set; }
        //public virtual DbSet<DETALLE_FLUJO> DETALLE_FLUJO { get; set; }
        //public virtual DbSet<DETALLE_FLUJO_CAJA> DETALLE_FLUJO_CAJA { get; set; }
        //public virtual DbSet<DETALLE_FLUJO_CAJA_EJECUTA> DETALLE_FLUJO_CAJA_EJECUTA { get; set; }
        //public virtual DbSet<DETALLE_INVERSION> DETALLE_INVERSION { get; set; }
        //public virtual DbSet<DETALLE_PERFIL_CLI> DETALLE_PERFIL_CLI { get; set; }
        //public virtual DbSet<DETALLE_PREASIENTO> DETALLE_PREASIENTO { get; set; }
        //public virtual DbSet<DETALLE_PRESUP> DETALLE_PRESUP { get; set; }
        //public virtual DbSet<DETALLE_PROYECCION> DETALLE_PROYECCION { get; set; }
        //public virtual DbSet<DETALLE_RETENCION> DETALLE_RETENCION { get; set; }
        //public virtual DbSet<DETALLE_RETENCION_CO> DETALLE_RETENCION_CO { get; set; }
        //public virtual DbSet<DEVOL_LIN_EMBARQUE> DEVOL_LIN_EMBARQUE { get; set; }
        //public virtual DbSet<DEVOLUCION> DEVOLUCION { get; set; }
        //public virtual DbSet<DIARIO> DIARIO { get; set; }
        //public virtual DbSet<DIAS_FERIADOS> DIAS_FERIADOS { get; set; }
        //public virtual DbSet<DIFERIDO> DIFERIDO { get; set; }
        //public virtual DbSet<DIFERIDO_DOC_CP> DIFERIDO_DOC_CP { get; set; }
        //public virtual DbSet<DIFERIDOS_IMPUESTOS> DIFERIDOS_IMPUESTOS { get; set; }
        //public virtual DbSet<DIRECC_CLIENTE_POS> DIRECC_CLIENTE_POS { get; set; }
        //public virtual DbSet<DIRECC_EMBARQUE> DIRECC_EMBARQUE { get; set; }
        //public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        //public virtual DbSet<DIRECCION_EMBARQUE> DIRECCION_EMBARQUE { get; set; }
        //public virtual DbSet<DISTRIBUCION_ARTICULO> DISTRIBUCION_ARTICULO { get; set; }
        //public virtual DbSet<DIVISION_GEOGRAFICA1> DIVISION_GEOGRAFICA1 { get; set; }
        //public virtual DbSet<DIVISION_GEOGRAFICA2> DIVISION_GEOGRAFICA2 { get; set; }
        //public virtual DbSet<DIVISION_GEOGRAFICA3> DIVISION_GEOGRAFICA3 { get; set; }
        //public virtual DbSet<DIVISION_GEOGRAFICA4> DIVISION_GEOGRAFICA4 { get; set; }
        //public virtual DbSet<DOC_ADJUNTO> DOC_ADJUNTO { get; set; }
        //public virtual DbSet<DOC_ELECTRONICO_PROCESADO> DOC_ELECTRONICO_PROCESADO { get; set; }
        //public virtual DbSet<DOC_ESPERA_SERIE_POS> DOC_ESPERA_SERIE_POS { get; set; }
        //public virtual DbSet<DOC_POS_CARGA> DOC_POS_CARGA { get; set; }
        //public virtual DbSet<DOC_POS_LINEA> DOC_POS_LINEA { get; set; }
        //public virtual DbSet<DOC_POS_RETENCION> DOC_POS_RETENCION { get; set; }
        //public virtual DbSet<DOCCP_MOVEJERCIDO> DOCCP_MOVEJERCIDO { get; set; }
        //public virtual DbSet<DOCCP_MOVPAGO> DOCCP_MOVPAGO { get; set; }
        //public virtual DbSet<DOCS_EQUIPO> DOCS_EQUIPO { get; set; }
        //public virtual DbSet<DOCS_PROCEDIM> DOCS_PROCEDIM { get; set; }
        //public virtual DbSet<DOCS_SOPORTE> DOCS_SOPORTE { get; set; }
        //public virtual DbSet<DOCUMENTO> DOCUMENTO { get; set; }
        //public virtual DbSet<DOCUMENTO_ANTICIPO> DOCUMENTO_ANTICIPO { get; set; }
        //public virtual DbSet<DOCUMENTO_ASOCIADO> DOCUMENTO_ASOCIADO { get; set; }
        //public virtual DbSet<DOCUMENTO_ELECTRONICO> DOCUMENTO_ELECTRONICO { get; set; }
        //public virtual DbSet<DOCUMENTO_ELECTRONICO_FA> DOCUMENTO_ELECTRONICO_FA { get; set; }
        //public virtual DbSet<DOCUMENTO_EMBARQUE> DOCUMENTO_EMBARQUE { get; set; }
        //public virtual DbSet<DOCUMENTO_EN_ESPERA> DOCUMENTO_EN_ESPERA { get; set; }
        //public virtual DbSet<DOCUMENTO_INV> DOCUMENTO_INV { get; set; }
        //public virtual DbSet<DOCUMENTO_LINEA_ESPERA> DOCUMENTO_LINEA_ESPERA { get; set; }
        //public virtual DbSet<DOCUMENTO_POS> DOCUMENTO_POS { get; set; }
        //public virtual DbSet<DOCUMENTOS_CC> DOCUMENTOS_CC { get; set; }
        //public virtual DbSet<DOCUMENTOS_CP> DOCUMENTOS_CP { get; set; }
        //public virtual DbSet<DOCUMENTOS_RH> DOCUMENTOS_RH { get; set; }
        //public virtual DbSet<ELIMINACION_SINCRO_POS> ELIMINACION_SINCRO_POS { get; set; }
        //public virtual DbSet<EMBARQUE> EMBARQUE { get; set; }
        //public virtual DbSet<EMBARQUE_DOC_CP> EMBARQUE_DOC_CP { get; set; }
        //public virtual DbSet<EMBARQUE_IMP> EMBARQUE_IMP { get; set; }
        //public virtual DbSet<EMBARQUE_LINEA> EMBARQUE_LINEA { get; set; }
        //public virtual DbSet<EMBARQUE_MOV_PRES> EMBARQUE_MOV_PRES { get; set; }
        //public virtual DbSet<EMP_CONC_LIQUIDAC> EMP_CONC_LIQUIDAC { get; set; }
        //public virtual DbSet<EMP_EXPERIENCIA> EMP_EXPERIENCIA { get; set; }
        //public virtual DbSet<EMP_SALDO_VAC_ACC> EMP_SALDO_VAC_ACC { get; set; }
        //public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        //public virtual DbSet<EMPLEADO_ACADEMICO> EMPLEADO_ACADEMICO { get; set; }
        //public virtual DbSet<EMPLEADO_ACC_PER> EMPLEADO_ACC_PER { get; set; }
        //public virtual DbSet<EMPLEADO_ACC_SALDO> EMPLEADO_ACC_SALDO { get; set; }
        //public virtual DbSet<EMPLEADO_ACCIDENTE> EMPLEADO_ACCIDENTE { get; set; }
        //public virtual DbSet<EMPLEADO_AUDITORIA> EMPLEADO_AUDITORIA { get; set; }
        //public virtual DbSet<EMPLEADO_AUSENCIA> EMPLEADO_AUSENCIA { get; set; }
        //public virtual DbSet<EMPLEADO_CALENDAR> EMPLEADO_CALENDAR { get; set; }
        //public virtual DbSet<EMPLEADO_CENTRO> EMPLEADO_CENTRO { get; set; }
        //public virtual DbSet<EMPLEADO_COMPROBANTE> EMPLEADO_COMPROBANTE { get; set; }
        //public virtual DbSet<EMPLEADO_CONC_NOMI> EMPLEADO_CONC_NOMI { get; set; }
        //public virtual DbSet<EMPLEADO_CONC_NOMI_CALC> EMPLEADO_CONC_NOMI_CALC { get; set; }
        //public virtual DbSet<EMPLEADO_CONCEPTO> EMPLEADO_CONCEPTO { get; set; }
        //public virtual DbSet<EMPLEADO_CONTRATO> EMPLEADO_CONTRATO { get; set; }
        //public virtual DbSet<EMPLEADO_DOCUMENTO> EMPLEADO_DOCUMENTO { get; set; }
        //public virtual DbSet<EMPLEADO_EVALUACIO> EMPLEADO_EVALUACIO { get; set; }
        //public virtual DbSet<EMPLEADO_JERARQUIA> EMPLEADO_JERARQUIA { get; set; }
        //public virtual DbSet<EMPLEADO_NOMI_NETO> EMPLEADO_NOMI_NETO { get; set; }
        //public virtual DbSet<EMPLEADO_NOMINA_CFDI> EMPLEADO_NOMINA_CFDI { get; set; }
        //public virtual DbSet<EMPLEADO_NOMINA_CFDI_CONCEPTO> EMPLEADO_NOMINA_CFDI_CONCEPTO { get; set; }
        //public virtual DbSet<EMPLEADO_NOTAS> EMPLEADO_NOTAS { get; set; }
        //public virtual DbSet<EMPLEADO_PARIENTE> EMPLEADO_PARIENTE { get; set; }
        //public virtual DbSet<EMPLEADO_SALDO_VAC> EMPLEADO_SALDO_VAC { get; set; }
        //public virtual DbSet<EMPLEADO_VACACION> EMPLEADO_VACACION { get; set; }
        //public virtual DbSet<EMPLEADOS_X_RANGO> EMPLEADOS_X_RANGO { get; set; }
        //public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        //public virtual DbSet<ENC_MOV_APLICADO> ENC_MOV_APLICADO { get; set; }
        //public virtual DbSet<ENC_MOV_NOAPLICADO> ENC_MOV_NOAPLICADO { get; set; }
        //public virtual DbSet<ENC_TABLA_UDF> ENC_TABLA_UDF { get; set; }
        //public virtual DbSet<ENTIDAD_FINANCIERA> ENTIDAD_FINANCIERA { get; set; }
        //public virtual DbSet<EQUIPO> EQUIPO { get; set; }
        //public virtual DbSet<EQUIPO_EQUIVALENTE> EQUIPO_EQUIVALENTE { get; set; }
        //public virtual DbSet<EQUIPO_PARENTESCO> EQUIPO_PARENTESCO { get; set; }
        //public virtual DbSet<EQUIPO_PREVENT> EQUIPO_PREVENT { get; set; }
        //public virtual DbSet<ERROR_CAJA> ERROR_CAJA { get; set; }
        //public virtual DbSet<ESCALA_BONIF> ESCALA_BONIF { get; set; }
        //public virtual DbSet<ESCALA_DCTO> ESCALA_DCTO { get; set; }
        //public virtual DbSet<ESPEC_EQUIPO> ESPEC_EQUIPO { get; set; }
        //public virtual DbSet<ESTADO_ACTIVO> ESTADO_ACTIVO { get; set; }
        //public virtual DbSet<ESTADO_EMPLEADO> ESTADO_EMPLEADO { get; set; }
        //public virtual DbSet<EVALPROV> EVALPROV { get; set; }
        //public virtual DbSet<EXCEP_CIUDAD> EXCEP_CIUDAD { get; set; }
        //public virtual DbSet<EXCEP_REGIMEN> EXCEP_REGIMEN { get; set; }
        //public virtual DbSet<EXCEPCION_ARANCEL_IMP> EXCEPCION_ARANCEL_IMP { get; set; }
        //public virtual DbSet<EXCEPCION_ARANCEL_PAIS> EXCEPCION_ARANCEL_PAIS { get; set; }
        //public virtual DbSet<EXCEPCION_D104> EXCEPCION_D104 { get; set; }
        public virtual DbSet<EXISTENCIA_BODEGA> EXISTENCIA_BODEGA { get; set; }
        //public virtual DbSet<EXISTENCIA_CIERRE> EXISTENCIA_CIERRE { get; set; }
        //public virtual DbSet<EXISTENCIA_LOTE> EXISTENCIA_LOTE { get; set; }
        //public virtual DbSet<EXISTENCIA_RESERVA> EXISTENCIA_RESERVA { get; set; }
        //public virtual DbSet<EXISTENCIA_SERIE> EXISTENCIA_SERIE { get; set; }
        //public virtual DbSet<EXT_MOV_APLICADO> EXT_MOV_APLICADO { get; set; }
        //public virtual DbSet<EXT_MOV_NOAPLICADO> EXT_MOV_NOAPLICADO { get; set; }
        //public virtual DbSet<FACT_PROC_MEDIC> FACT_PROC_MEDIC { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        //public virtual DbSet<FACTURA_ADUANA> FACTURA_ADUANA { get; set; }
        //public virtual DbSet<FACTURA_ADUANA_CMP> FACTURA_ADUANA_CMP { get; set; }
        //public virtual DbSet<FACTURA_CANCELA> FACTURA_CANCELA { get; set; }
        //public virtual DbSet<FACTURA_DEVUELTA> FACTURA_DEVUELTA { get; set; }
        //public virtual DbSet<FACTURA_DOC_CC> FACTURA_DOC_CC { get; set; }
        public virtual DbSet<FACTURA_LINEA> FACTURA_LINEA { get; set; }
        //public virtual DbSet<FACTURA_RETENCION> FACTURA_RETENCION { get; set; }
        //public virtual DbSet<FECHA> FECHA { get; set; }
        //public virtual DbSet<FIADORES_DOC_CC> FIADORES_DOC_CC { get; set; }
        //public virtual DbSet<FIADORES_DOC_CO> FIADORES_DOC_CO { get; set; }
        //public virtual DbSet<FIADORES_DOC_CP> FIADORES_DOC_CP { get; set; }
        //public virtual DbSet<FIADORES_DOC_FA> FIADORES_DOC_FA { get; set; }
        //public virtual DbSet<FIADORES_PED_FA> FIADORES_PED_FA { get; set; }
        //public virtual DbSet<FILTRO_EMPLEADO_REPORTES> FILTRO_EMPLEADO_REPORTES { get; set; }
        //public virtual DbSet<FLUJO_CAJA> FLUJO_CAJA { get; set; }
        //public virtual DbSet<FLUJO_CAJA_CUENTA_BANCO> FLUJO_CAJA_CUENTA_BANCO { get; set; }
        public virtual DbSet<FORMA_PAGOS> FORMA_PAGOS { get; set; }
        //public virtual DbSet<FORMA_PAGO_DE> FORMA_PAGO_DE { get; set; }
        //public virtual DbSet<FORMATO> FORMATO { get; set; }
        //public virtual DbSet<FORMATO_COLUMNA> FORMATO_COLUMNA { get; set; }
        //public virtual DbSet<FORMATO_ORDEN> FORMATO_ORDEN { get; set; }
        //public virtual DbSet<FORMATO_PLANIFICACION> FORMATO_PLANIFICACION { get; set; }
        //public virtual DbSet<FORMATO_TRAN_PARAM> FORMATO_TRAN_PARAM { get; set; }
        //public virtual DbSet<FORMATO_TRAN_SFTP> FORMATO_TRAN_SFTP { get; set; }
        //public virtual DbSet<FORMATO_TRANSFER> FORMATO_TRANSFER { get; set; }
        //public virtual DbSet<FORMATO_USUARIO> FORMATO_USUARIO { get; set; }
        //public virtual DbSet<GARANTIAS_DOC_CC> GARANTIAS_DOC_CC { get; set; }
        //public virtual DbSet<GARANTIAS_DOC_CO> GARANTIAS_DOC_CO { get; set; }
        //public virtual DbSet<GARANTIAS_DOC_CP> GARANTIAS_DOC_CP { get; set; }
        //public virtual DbSet<GARANTIAS_DOC_FA> GARANTIAS_DOC_FA { get; set; }
        //public virtual DbSet<GARANTIAS_PED_FA> GARANTIAS_PED_FA { get; set; }
        //public virtual DbSet<GASTO_COMPRA> GASTO_COMPRA { get; set; }
        //public virtual DbSet<GLOBALES> GLOBALES { get; set; }
        //public virtual DbSet<GLOBALES_CRGMVPRP> GLOBALES_CRGMVPRP { get; set; }
        //public virtual DbSet<GLOBALES_PR> GLOBALES_PR { get; set; }
        public virtual DbSet<Grupos> Grupo { get; set; }
        public virtual DbSet<Grupo_Caja> Grupo_Caja { get; set; }
        //public virtual DbSet<GRUPO_CONCEPTO> GRUPO_CONCEPTO { get; set; }
        //public virtual DbSet<GRUPO_CONCEPTO_DET> GRUPO_CONCEPTO_DET { get; set; }
        //public virtual DbSet<GUID_RELACIONADO> GUID_RELACIONADO { get; set; }
        //public virtual DbSet<HIST_CIERRE_CG> HIST_CIERRE_CG { get; set; }
        //public virtual DbSet<HIST_DEPRECIACION> HIST_DEPRECIACION { get; set; }
        //public virtual DbSet<HIST_DETERIORO> HIST_DETERIORO { get; set; }
        //public virtual DbSet<HIST_DIFCAM_CB> HIST_DIFCAM_CB { get; set; }
        //public virtual DbSet<HIST_DIFCAM_CC> HIST_DIFCAM_CC { get; set; }
        //public virtual DbSet<HIST_DIFCAM_CG> HIST_DIFCAM_CG { get; set; }
        //public virtual DbSet<HIST_DIFCAM_CP> HIST_DIFCAM_CP { get; set; }
        //public virtual DbSet<HIST_MEMBRESIA_POS> HIST_MEMBRESIA_POS { get; set; }
        //public virtual DbSet<HISTORIAL_DESCUENTOS> HISTORIAL_DESCUENTOS { get; set; }
        //public virtual DbSet<HISTORICO_DIFERIDO> HISTORICO_DIFERIDO { get; set; }
        //public virtual DbSet<HISTORICO_EMPLEADO> HISTORICO_EMPLEADO { get; set; }
        //public virtual DbSet<HORA_LABORADA> HORA_LABORADA { get; set; }
        //public virtual DbSet<HORARIO> HORARIO { get; set; }
        //public virtual DbSet<HORARIO_CONCEPTO> HORARIO_CONCEPTO { get; set; }
        //public virtual DbSet<IMAGEN> IMAGEN { get; set; }
        //public virtual DbSet<IMPUESTO> IMPUESTO { get; set; }
        //public virtual DbSet<IMPUESTO_ACTIVO> IMPUESTO_ACTIVO { get; set; }
        //public virtual DbSet<IMPUESTO_ADICIONAL> IMPUESTO_ADICIONAL { get; set; }
        //public virtual DbSet<IMPUESTO_COMPRA> IMPUESTO_COMPRA { get; set; }
        //public virtual DbSet<IMPUESTO_DONDE> IMPUESTO_DONDE { get; set; }
        //public virtual DbSet<IMPUESTO_EXPAND> IMPUESTO_EXPAND { get; set; }
        //public virtual DbSet<IMPUESTO_FORMULA> IMPUESTO_FORMULA { get; set; }
        //public virtual DbSet<INCONSIST_INV_POS> INCONSIST_INV_POS { get; set; }
        //public virtual DbSet<INDICADOR> INDICADOR { get; set; }
        //public virtual DbSet<INDICADOR_CR> INDICADOR_CR { get; set; }
        //public virtual DbSet<INDICADOR_VALOR> INDICADOR_VALOR { get; set; }
        //public virtual DbSet<INDICADOR_VALOR_CR> INDICADOR_VALOR_CR { get; set; }
        //public virtual DbSet<INDICE_PRECIOS> INDICE_PRECIOS { get; set; }
        //public virtual DbSet<INFO_DOC_SEGURO> INFO_DOC_SEGURO { get; set; }
        //public virtual DbSet<INFO_REG_BILLETE> INFO_REG_BILLETE { get; set; }
        //public virtual DbSet<INGRESOS_LOTE> INGRESOS_LOTE { get; set; }
        //public virtual DbSet<INVERSION> INVERSION { get; set; }
        //public virtual DbSet<ITEMS_HACIENDA> ITEMS_HACIENDA { get; set; }
        //public virtual DbSet<LINEA_DOC_INV> LINEA_DOC_INV { get; set; }
        //public virtual DbSet<LINEASPEDIDO_EDI> LINEASPEDIDO_EDI { get; set; }
        //public virtual DbSet<LIQUIDAC_COMPRA> LIQUIDAC_COMPRA { get; set; }
        //public virtual DbSet<LIQUIDAC_DETALLE> LIQUIDAC_DETALLE { get; set; }
        //public virtual DbSet<LIQUIDAC_GASTO> LIQUIDAC_GASTO { get; set; }
        //public virtual DbSet<LIQUIDAC_MENSAJE> LIQUIDAC_MENSAJE { get; set; }
        //public virtual DbSet<LIQUIDACION> LIQUIDACION { get; set; }
        //public virtual DbSet<LIQUIDACION_APORTE> LIQUIDACION_APORTE { get; set; }
        //public virtual DbSet<LIQUIDACION_CONCEP> LIQUIDACION_CONCEP { get; set; }
        //public virtual DbSet<LIQUIDACION_CONTRA> LIQUIDACION_CONTRA { get; set; }
        //public virtual DbSet<LIQUIDACION_PAGO> LIQUIDACION_PAGO { get; set; }
        //public virtual DbSet<LOCALIZACION> LOCALIZACION { get; set; }
        //public virtual DbSet<LOCKS> LOCKS { get; set; }
        //public virtual DbSet<LOTE> LOTE { get; set; }
        //public virtual DbSet<LOTE_ESPE> LOTE_ESPE { get; set; }
        //public virtual DbSet<MAPEO_CONTABLE> MAPEO_CONTABLE { get; set; }
        //public virtual DbSet<MARCA> MARCA { get; set; }
        //public virtual DbSet<MARCA_RELOJ> MARCA_RELOJ { get; set; }
        //public virtual DbSet<MATRIZ_OPER_INVENTARIO> MATRIZ_OPER_INVENTARIO { get; set; }
        //public virtual DbSet<MAYOR> MAYOR { get; set; }
        //public virtual DbSet<MAYOR_AUDITORIA> MAYOR_AUDITORIA { get; set; }
        //public virtual DbSet<MAYOR_DIVISION_GEOGRAFICA> MAYOR_DIVISION_GEOGRAFICA { get; set; }
        //public virtual DbSet<MAYOR_LINEA_PRES> MAYOR_LINEA_PRES { get; set; }
        //public virtual DbSet<MEDICION> MEDICION { get; set; }
        //public virtual DbSet<MEMBRESIA_POS> MEMBRESIA_POS { get; set; }
        //public virtual DbSet<MEN_MOV_NOAPLICADO> MEN_MOV_NOAPLICADO { get; set; }
        //public virtual DbSet<MENSAJERO> MENSAJERO { get; set; }
        //public virtual DbSet<META> META { get; set; }
        //public virtual DbSet<META_DETALLE> META_DETALLE { get; set; }
        //public virtual DbSet<METODO_PAGO> METODO_PAGO { get; set; }
        //public virtual DbSet<MODELO_RETENCION> MODELO_RETENCION { get; set; }
        //public virtual DbSet<MONEDA> MONEDA { get; set; }
        public virtual DbSet<MONEDA_HIST> MONEDA_HIST { get; set; }
        //public virtual DbSet<MONEDA_PED_BACKORD> MONEDA_PED_BACKORD { get; set; }
        //public virtual DbSet<MONITOR_CATEGORIA> MONITOR_CATEGORIA { get; set; }
        //public virtual DbSet<MONITOR_COLUMNAS> MONITOR_COLUMNAS { get; set; }
        //public virtual DbSet<MONITOR_CONSULTA> MONITOR_CONSULTA { get; set; }
        //public virtual DbSet<MOTIVO_CANCEL_EXPR> MOTIVO_CANCEL_EXPR { get; set; }
        //public virtual DbSet<MOV_BANCOS> MOV_BANCOS { get; set; }
        //public virtual DbSet<MOV_BANCOS_RUBROS_CF> MOV_BANCOS_RUBROS_CF { get; set; }
        //public virtual DbSet<MOV_PRESUPUESTAL> MOV_PRESUPUESTAL { get; set; }
        //public virtual DbSet<MOV_PROCESADOS> MOV_PROCESADOS { get; set; }
        //public virtual DbSet<MOV_REPORTADOS> MOV_REPORTADOS { get; set; }
        //public virtual DbSet<MOVIMIENTO_BASE> MOVIMIENTO_BASE { get; set; }
        //public virtual DbSet<MRP_AjusteCostoEstandar> MRP_AjusteCostoEstandar { get; set; }
        //public virtual DbSet<NCF_CAJA_POS> NCF_CAJA_POS { get; set; }
        //public virtual DbSet<NCF_CONSECUTIVO> NCF_CONSECUTIVO { get; set; }
        //public virtual DbSet<NCF_CONSECUTIVO_USUARIO> NCF_CONSECUTIVO_USUARIO { get; set; }
        //public virtual DbSet<NCF_DOCUMENTO> NCF_DOCUMENTO { get; set; }
        //public virtual DbSet<NCF_SECUENCIA> NCF_SECUENCIA { get; set; }
        //public virtual DbSet<NIT> NIT { get; set; }
        //public virtual DbSet<NIVEL_PRECIO> NIVEL_PRECIO { get; set; }
        //public virtual DbSet<NOMINA> NOMINA { get; set; }
        //public virtual DbSet<NOMINA_BANCO> NOMINA_BANCO { get; set; }
        //public virtual DbSet<NOMINA_CONCEPTO> NOMINA_CONCEPTO { get; set; }
        //public virtual DbSet<NOMINA_HISTORICO> NOMINA_HISTORICO { get; set; }
        //public virtual DbSet<NOMINA_USUARIO> NOMINA_USUARIO { get; set; }
        //public virtual DbSet<ORDEN_COMPRA> ORDEN_COMPRA { get; set; }
        //public virtual DbSet<ORDEN_COMPRA_IMP> ORDEN_COMPRA_IMP { get; set; }
        //public virtual DbSet<ORDEN_COMPRA_LINEA> ORDEN_COMPRA_LINEA { get; set; }
        //public virtual DbSet<ORDEN_MOV_PRES> ORDEN_MOV_PRES { get; set; }
        //public virtual DbSet<ORDEN_TRABAJO> ORDEN_TRABAJO { get; set; }
        //public virtual DbSet<OT_ARTICULO> OT_ARTICULO { get; set; }
        //public virtual DbSet<OT_DETALLE> OT_DETALLE { get; set; }
        //public virtual DbSet<OT_EQUIPO> OT_EQUIPO { get; set; }
        //public virtual DbSet<OT_GASTO> OT_GASTO { get; set; }
        //public virtual DbSet<OT_NOTAS> OT_NOTAS { get; set; }
        //public virtual DbSet<OT_PLAN_TRABAJO> OT_PLAN_TRABAJO { get; set; }
        //public virtual DbSet<OT_PUESTO> OT_PUESTO { get; set; }
        //public virtual DbSet<OT_REPORTE_CONSUMO> OT_REPORTE_CONSUMO { get; set; }
        //public virtual DbSet<OT_REPORTE_LABOR> OT_REPORTE_LABOR { get; set; }
        //public virtual DbSet<PAGO_POS> PAGO_POS { get; set; }
        //public virtual DbSet<PAGOS_PARCIALES> PAGOS_PARCIALES { get; set; }
        //public virtual DbSet<PAIS> PAIS { get; set; }
        //public virtual DbSet<PAQ_DESC_GRUPO> PAQ_DESC_GRUPO { get; set; }
        //public virtual DbSet<PAQ_DESC_REG_DESC> PAQ_DESC_REG_DESC { get; set; }
        //public virtual DbSet<PAQUETE> PAQUETE { get; set; }
        //public virtual DbSet<PAQUETE_CR> PAQUETE_CR { get; set; }
        //public virtual DbSet<PAQUETE_DESCUENTO> PAQUETE_DESCUENTO { get; set; }
        //public virtual DbSet<PAQUETE_INVENTARIO> PAQUETE_INVENTARIO { get; set; }
        //public virtual DbSet<PARCIALIDADES_CC> PARCIALIDADES_CC { get; set; }
        //public virtual DbSet<PARCIALIDADES_CO> PARCIALIDADES_CO { get; set; }
        //public virtual DbSet<PARCIALIDADES_CP> PARCIALIDADES_CP { get; set; }
        //public virtual DbSet<PARTICIPANTE> PARTICIPANTE { get; set; }
        //public virtual DbSet<PARTIDA> PARTIDA { get; set; }
        //public virtual DbSet<PARTIDA_CR> PARTIDA_CR { get; set; }
        //public virtual DbSet<PED_LINEA_SERIE_AD> PED_LINEA_SERIE_AD { get; set; }
        //public virtual DbSet<PEDIDO> PEDIDO { get; set; }
        //public virtual DbSet<PEDIDO_AD> PEDIDO_AD { get; set; }
        //public virtual DbSet<PEDIDO_AUTORIZA> PEDIDO_AUTORIZA { get; set; }
        //public virtual DbSet<PEDIDO_EDI> PEDIDO_EDI { get; set; }
        //public virtual DbSet<PEDIDO_LINEA> PEDIDO_LINEA { get; set; }
        //public virtual DbSet<PEDIDO_LINEA_AD> PEDIDO_LINEA_AD { get; set; }
        //public virtual DbSet<PEDIDO_SUGERIDO> PEDIDO_SUGERIDO { get; set; }
        //public virtual DbSet<PEDIMENTO> PEDIMENTO { get; set; }
        //public virtual DbSet<PEDIMENTO_LOTE> PEDIMENTO_LOTE { get; set; }
        //public virtual DbSet<PERFIL_CLIENTE> PERFIL_CLIENTE { get; set; }
        //public virtual DbSet<PERIODO_CONTABLE> PERIODO_CONTABLE { get; set; }
        //public virtual DbSet<PERIODO_PRESUP> PERIODO_PRESUP { get; set; }
        //public virtual DbSet<PERIODOS_FLUJO_CAJA> PERIODOS_FLUJO_CAJA { get; set; }
        //public virtual DbSet<PILA_HISTORICO> PILA_HISTORICO { get; set; }
        //public virtual DbSet<PILA_HISTORICO_DET> PILA_HISTORICO_DET { get; set; }
        //public virtual DbSet<PISTA_EXISTEN_DET> PISTA_EXISTEN_DET { get; set; }
        //public virtual DbSet<PISTA_EXISTENCIA> PISTA_EXISTENCIA { get; set; }
        //public virtual DbSet<PLAN_PAGO_DOC> PLAN_PAGO_DOC { get; set; }
        //public virtual DbSet<PLAN_PAGO_PED> PLAN_PAGO_PED { get; set; }
        //public virtual DbSet<PLAZA> PLAZA { get; set; }
        //public virtual DbSet<PRE_AJUSTE> PRE_AJUSTE { get; set; }
        //public virtual DbSet<PRE_AJUSTE_DETALLE> PRE_AJUSTE_DETALLE { get; set; }
        //public virtual DbSet<PRE_OBLIGACION> PRE_OBLIGACION { get; set; }
        //public virtual DbSet<PRE_OBLIGACION_DET> PRE_OBLIGACION_DET { get; set; }
        //public virtual DbSet<PREASIENTO> PREASIENTO { get; set; }
        //public virtual DbSet<PRECIO_ART_PROV> PRECIO_ART_PROV { get; set; }
        //public virtual DbSet<PRECIO_REFERENCIA_DE> PRECIO_REFERENCIA_DE { get; set; }
        //public virtual DbSet<PREFERENCIA> PREFERENCIA { get; set; }
        //public virtual DbSet<PRESU_USUARIO> PRESU_USUARIO { get; set; }
        //public virtual DbSet<PRESUPUEST_DETALLE> PRESUPUEST_DETALLE { get; set; }
        //public virtual DbSet<PRESUPUEST_PARTIDA> PRESUPUEST_PARTIDA { get; set; }
        //public virtual DbSet<PRESUPUESTO> PRESUPUESTO { get; set; }
        //public virtual DbSet<PRESUPUESTO_BI> PRESUPUESTO_BI { get; set; }
        //public virtual DbSet<PRESUPUESTO_CENTRO_BI> PRESUPUESTO_CENTRO_BI { get; set; }
        //public virtual DbSet<PRESUPUESTO_CONTAB> PRESUPUESTO_CONTAB { get; set; }
        //public virtual DbSet<PRESUPUESTO_CR> PRESUPUESTO_CR { get; set; }
        //public virtual DbSet<PRESUPUESTO_CUENTA_BI> PRESUPUESTO_CUENTA_BI { get; set; }
        //public virtual DbSet<PRESUPUESTO_DETALLE_BI> PRESUPUESTO_DETALLE_BI { get; set; }
        //public virtual DbSet<PRESUPUESTO_NOTAS> PRESUPUESTO_NOTAS { get; set; }
        //public virtual DbSet<PRESUPUESTO_TIPOCAM_BI> PRESUPUESTO_TIPOCAM_BI { get; set; }
        //public virtual DbSet<PRESUPUESTO_VERSION_BI> PRESUPUESTO_VERSION_BI { get; set; }
        //public virtual DbSet<PRIVILEGIO_SISTEMA> PRIVILEGIO_SISTEMA { get; set; }
        //public virtual DbSet<PROC_ARTICULO> PROC_ARTICULO { get; set; }
        //public virtual DbSet<PROC_EQ_PREVENT> PROC_EQ_PREVENT { get; set; }
        //public virtual DbSet<PROC_EQ_PREVENT_MED> PROC_EQ_PREVENT_MED { get; set; }
        //public virtual DbSet<PROC_EQUIPO> PROC_EQUIPO { get; set; }
        //public virtual DbSet<PROC_NOTAS> PROC_NOTAS { get; set; }
        //public virtual DbSet<PROC_PUESTO> PROC_PUESTO { get; set; }
        //public virtual DbSet<PROCEDIMIENTO> PROCEDIMIENTO { get; set; }
        //public virtual DbSet<PROCESOCH> PROCESOCH { get; set; }
        //public virtual DbSet<PRON_DET_DIARIO> PRON_DET_DIARIO { get; set; }
        //public virtual DbSet<PRON_DET_PERIODO> PRON_DET_PERIODO { get; set; }
        //public virtual DbSet<PRON_PRDO_MENSAJE> PRON_PRDO_MENSAJE { get; set; }
        //public virtual DbSet<PRONOSTICO> PRONOSTICO { get; set; }
        //public virtual DbSet<PRONOSTICO_DETALLE> PRONOSTICO_DETALLE { get; set; }
        //public virtual DbSet<PRONOSTICO_FILTRO> PRONOSTICO_FILTRO { get; set; }
        //public virtual DbSet<PRONOSTICO_ORDEN> PRONOSTICO_ORDEN { get; set; }
        //public virtual DbSet<PRONOSTICO_USUARIO> PRONOSTICO_USUARIO { get; set; }
        //public virtual DbSet<PROV_RETENCION> PROV_RETENCION { get; set; }
        //public virtual DbSet<PROV_VALORES_CERTIF> PROV_VALORES_CERTIF { get; set; }
        //public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        //public virtual DbSet<PROVEEDOR_ENTIDAD> PROVEEDOR_ENTIDAD { get; set; }
        //public virtual DbSet<PROYECCION> PROYECCION { get; set; }
        //public virtual DbSet<PTO_EXTERNO_PUESTO> PTO_EXTERNO_PUESTO { get; set; }
        //public virtual DbSet<PUESTO> PUESTO { get; set; }
        //public virtual DbSet<PUESTO_EXTERNO> PUESTO_EXTERNO { get; set; }
        //public virtual DbSet<PUESTO_FUNCIONES> PUESTO_FUNCIONES { get; set; }
        //public virtual DbSet<PUESTO_SALARIO> PUESTO_SALARIO { get; set; }
        //public virtual DbSet<RANGOS_AUTORIZA_DEP> RANGOS_AUTORIZA_DEP { get; set; }
        //public virtual DbSet<RANGOS_CAI> RANGOS_CAI { get; set; }
        //public virtual DbSet<RATIOS> RATIOS { get; set; }
        //public virtual DbSet<RATIOS_CUENTAS> RATIOS_CUENTAS { get; set; }
        //public virtual DbSet<RECEPCION_DETRAC> RECEPCION_DETRAC { get; set; }
        //public virtual DbSet<REFERENCIA> REFERENCIA { get; set; }
        //public virtual DbSet<REGIMEN_VAC_CONTRI> REGIMEN_VAC_CONTRI { get; set; }
        //public virtual DbSet<REGIMEN_VACACIONAL> REGIMEN_VACACIONAL { get; set; }
        //public virtual DbSet<REGIMENES> REGIMENES { get; set; }
        //public virtual DbSet<REGION> REGION { get; set; }
        //public virtual DbSet<REGION_DET> REGION_DET { get; set; }
        //public virtual DbSet<REGLA_ARTICULO> REGLA_ARTICULO { get; set; }
        //public virtual DbSet<REGLA_COMISION> REGLA_COMISION { get; set; }
        //public virtual DbSet<REGLA_DESCUENTO> REGLA_DESCUENTO { get; set; }
        //public virtual DbSet<REPORTE_LABOR> REPORTE_LABOR { get; set; }
        //public virtual DbSet<REPORTE_REPX> REPORTE_REPX { get; set; }
        //public virtual DbSet<REPORTES_CONTABLES> REPORTES_CONTABLES { get; set; }
        //public virtual DbSet<REQ_EXP_TRANS> REQ_EXP_TRANS { get; set; }
        //public virtual DbSet<RESOLUCION_DOC_ELECTRONICO> RESOLUCION_DOC_ELECTRONICO { get; set; }
        //public virtual DbSet<RESOLUCION_POS> RESOLUCION_POS { get; set; }
        //public virtual DbSet<RESPON_SEGUIMIENTO> RESPON_SEGUIMIENTO { get; set; }
        //public virtual DbSet<RESPONSABILIDAD_FISCAL> RESPONSABILIDAD_FISCAL { get; set; }
        //public virtual DbSet<RESPONSABLE> RESPONSABLE { get; set; }
        //public virtual DbSet<RETENCIONES> RETENCIONES { get; set; }
        //public virtual DbSet<RETENCIONES_DOC_CC> RETENCIONES_DOC_CC { get; set; }
        //public virtual DbSet<ROL_EQ_PREVENT> ROL_EQ_PREVENT { get; set; }
        //public virtual DbSet<RUBRO> RUBRO { get; set; }
        //public virtual DbSet<RUBRO_FLUJO_CAJA> RUBRO_FLUJO_CAJA { get; set; }
        //public virtual DbSet<RUTA> RUTA { get; set; }
        //public virtual DbSet<SAL_DIARIO_INT> SAL_DIARIO_INT { get; set; }
        //public virtual DbSet<SAL_DIARIO_INT_CON> SAL_DIARIO_INT_CON { get; set; }
        //public virtual DbSet<SAL_DIARIO_INT_DET> SAL_DIARIO_INT_DET { get; set; }
        //public virtual DbSet<SAL_DIARIO_INT_EMP> SAL_DIARIO_INT_EMP { get; set; }
        //public virtual DbSet<SALDO> SALDO { get; set; }
        //public virtual DbSet<SALDO_CLIENTE> SALDO_CLIENTE { get; set; }
        //public virtual DbSet<SALDO_NIT> SALDO_NIT { get; set; }
        //public virtual DbSet<SECCION_CUENTA> SECCION_CUENTA { get; set; }
        //public virtual DbSet<SECCION_REPORTES> SECCION_REPORTES { get; set; }
        //public virtual DbSet<SERIE_CADENA> SERIE_CADENA { get; set; }
        //public virtual DbSet<SERIE_CADENA_DET> SERIE_CADENA_DET { get; set; }
        //public virtual DbSet<SERIE_PLANTILLA> SERIE_PLANTILLA { get; set; }
        //public virtual DbSet<SISTEMA> SISTEMA { get; set; }
        //public virtual DbSet<SITIO_TIENDA> SITIO_TIENDA { get; set; }
        //public virtual DbSet<SOLICITUD_AF_AUDIT> SOLICITUD_AF_AUDIT { get; set; }
        //public virtual DbSet<SOLICITUD_AF_NOTIF> SOLICITUD_AF_NOTIF { get; set; }
        //public virtual DbSet<SOLICITUD_OC> SOLICITUD_OC { get; set; }
        //public virtual DbSet<SOLICITUD_OC_IMP> SOLICITUD_OC_IMP { get; set; }
        //public virtual DbSet<SOLICITUD_OC_LINEA> SOLICITUD_OC_LINEA { get; set; }
        //public virtual DbSet<SOLICITUD_ORDEN_CO> SOLICITUD_ORDEN_CO { get; set; }
        //public virtual DbSet<SOLICITUD_RH> SOLICITUD_RH { get; set; }
        //public virtual DbSet<SOLICITUD_RH_AUDIT> SOLICITUD_RH_AUDIT { get; set; }
        //public virtual DbSet<SOLICITUD_RH_DOC> SOLICITUD_RH_DOC { get; set; }
        //public virtual DbSet<SOLICITUD_RH_NOTIF> SOLICITUD_RH_NOTIF { get; set; }
        //public virtual DbSet<SOLICITUD_TRABAJO> SOLICITUD_TRABAJO { get; set; }
        //public virtual DbSet<SP_ARTICULO_TEMP> SP_ARTICULO_TEMP { get; set; }
        //public virtual DbSet<SP_PRONOSTICO> SP_PRONOSTICO { get; set; }
        //public virtual DbSet<SP_PRONOSTICO_DETALLE> SP_PRONOSTICO_DETALLE { get; set; }
        //public virtual DbSet<SP_VERSION_PLANIFICADOR_TEMP> SP_VERSION_PLANIFICADOR_TEMP { get; set; }
        //public virtual DbSet<ST_PATRON> ST_PATRON { get; set; }
        //public virtual DbSet<SUBSECCION_REPORTES> SUBSECCION_REPORTES { get; set; }
        //public virtual DbSet<SUBTIPO_COTIZANTE> SUBTIPO_COTIZANTE { get; set; }
        //public virtual DbSet<SUBTIPO_DOC_CB> SUBTIPO_DOC_CB { get; set; }
        //public virtual DbSet<SUBTIPO_DOC_CC> SUBTIPO_DOC_CC { get; set; }
        //public virtual DbSet<SUBTIPO_DOC_CP> SUBTIPO_DOC_CP { get; set; }
        //public virtual DbSet<SUPERVISOR> SUPERVISOR { get; set; }
        //public virtual DbSet<SUPERVISOR_AD> SUPERVISOR_AD { get; set; }
        //public virtual DbSet<TABLA_UDF> TABLA_UDF { get; set; }
        //public virtual DbSet<TEMP_HIST_DEPR> TEMP_HIST_DEPR { get; set; }
        //public virtual DbSet<TEMP_HIST_REVAL> TEMP_HIST_REVAL { get; set; }
        //public virtual DbSet<TEXTO_PRESUPUESTO> TEXTO_PRESUPUESTO { get; set; }
        //public virtual DbSet<TEXTOS_DOCS_CC> TEXTOS_DOCS_CC { get; set; }
        //public virtual DbSet<TIENDA_OFF_GRUPO> TIENDA_OFF_GRUPO { get; set; }
        //public virtual DbSet<TIENDA_OFFLINE> TIENDA_OFFLINE { get; set; }
        //public virtual DbSet<TIP_SOL_RH_USUARIO> TIP_SOL_RH_USUARIO { get; set; }
        //public virtual DbSet<TIPO_ACADEMICO> TIPO_ACADEMICO { get; set; }
        //public virtual DbSet<TIPO_ACCIDENTE> TIPO_ACCIDENTE { get; set; }
        //public virtual DbSet<TIPO_ACCION> TIPO_ACCION { get; set; }
        //public virtual DbSet<TIPO_ACCION_AF> TIPO_ACCION_AF { get; set; }
        //public virtual DbSet<TIPO_ACCION_CONCEP> TIPO_ACCION_CONCEP { get; set; }
        //public virtual DbSet<TIPO_ACCION_USUARIO> TIPO_ACCION_USUARIO { get; set; }
        //public virtual DbSet<TIPO_ACTIVO> TIPO_ACTIVO { get; set; }
        //public virtual DbSet<TIPO_AJUSTE> TIPO_AJUSTE { get; set; }
        //public virtual DbSet<TIPO_ANULACIONES> TIPO_ANULACIONES { get; set; }
        //public virtual DbSet<TIPO_ASIENTO> TIPO_ASIENTO { get; set; }
        //public virtual DbSet<TIPO_AUSENCIA> TIPO_AUSENCIA { get; set; }
        //public virtual DbSet<TIPO_CAMBIO> TIPO_CAMBIO { get; set; }
        //public virtual DbSet<TIPO_CAMBIO_HIST> TIPO_CAMBIO_HIST { get; set; }
        //public virtual DbSet<TIPO_CONTRATO> TIPO_CONTRATO { get; set; }
        //public virtual DbSet<TIPO_COTIZANTE> TIPO_COTIZANTE { get; set; }
        //public virtual DbSet<TIPO_CUENTA> TIPO_CUENTA { get; set; }
        //public virtual DbSet<TIPO_DESCUENTO> TIPO_DESCUENTO { get; set; }
        //public virtual DbSet<TIPO_DIFERIDO> TIPO_DIFERIDO { get; set; }
        //public virtual DbSet<TIPO_DOC_DEFAULT> TIPO_DOC_DEFAULT { get; set; }
        //public virtual DbSet<TIPO_EQUIPO> TIPO_EQUIPO { get; set; }
        //public virtual DbSet<TIPO_EQUIPO_PROC> TIPO_EQUIPO_PROC { get; set; }
        //public virtual DbSet<TIPO_EXISTENCIA> TIPO_EXISTENCIA { get; set; }
        //public virtual DbSet<TIPO_FACTURA> TIPO_FACTURA { get; set; }
        //public virtual DbSet<TIPO_FALLA> TIPO_FALLA { get; set; }
        //public virtual DbSet<TIPO_HERRAM> TIPO_HERRAM { get; set; }
        //public virtual DbSet<TIPO_IMPUESTO> TIPO_IMPUESTO { get; set; }
        //public virtual DbSet<TIPO_INDICE_PRECIO> TIPO_INDICE_PRECIO { get; set; }
        //public virtual DbSet<TIPO_NC> TIPO_NC { get; set; }
        //public virtual DbSet<TIPO_ND> TIPO_ND { get; set; }
        //public virtual DbSet<TIPO_NIT> TIPO_NIT { get; set; }
        //public virtual DbSet<TIPO_OPERACION> TIPO_OPERACION { get; set; }
        //public virtual DbSet<TIPO_PAGO> TIPO_PAGO { get; set; }
        //public virtual DbSet<TIPO_REFERENCIA_DE> TIPO_REFERENCIA_DE { get; set; }
        //public virtual DbSet<TIPO_SERVICIO_CB> TIPO_SERVICIO_CB { get; set; }
        //public virtual DbSet<TIPO_SERVICIO_CC> TIPO_SERVICIO_CC { get; set; }
        //public virtual DbSet<TIPO_SERVICIO_CP> TIPO_SERVICIO_CP { get; set; }
        //public virtual DbSet<TIPO_SOLI_RH_NOTIF> TIPO_SOLI_RH_NOTIF { get; set; }
        //public virtual DbSet<TIPO_SOLICITUD_RH> TIPO_SOLICITUD_RH { get; set; }
        //public virtual DbSet<TIPO_TARIFA_IVA> TIPO_TARIFA_IVA { get; set; }
        public virtual DbSet<TIPO_TARJETAS> TIPO_TARJETA { get; set; }

        //public virtual DbSet<TIPO_TARJETA_CAJA> TIPO_TARJETA_CAJA { get; set; }
        //public virtual DbSet<TIPO_TARJETA_POS> TIPO_TARJETA_POS { get; set; }
        //public virtual DbSet<TIPO_TRIBUTO> TIPO_TRIBUTO { get; set; }
        //public virtual DbSet<TIPOS_DETRACCIONES> TIPOS_DETRACCIONES { get; set; }
        //public virtual DbSet<TOMA_ACTIVO_ACCION> TOMA_ACTIVO_ACCION { get; set; }
        //public virtual DbSet<TOMA_ACTIVO_CAMBIO> TOMA_ACTIVO_CAMBIO { get; set; }
        //public virtual DbSet<TOMA_ACTIVO_CONTROL> TOMA_ACTIVO_CONTROL { get; set; }
        //public virtual DbSet<TOMA_ACTIVO_OBSERV> TOMA_ACTIVO_OBSERV { get; set; }
        //public virtual DbSet<TRANS_INV_AUX> TRANS_INV_AUX { get; set; }
        //public virtual DbSet<TRANSACCION_INV> TRANSACCION_INV { get; set; }
        //public virtual DbSet<TRANSACCION_MANT> TRANSACCION_MANT { get; set; }
        //public virtual DbSet<TRANSFERENCIA_CB> TRANSFERENCIA_CB { get; set; }
        //public virtual DbSet<TRASPASO_POS> TRASPASO_POS { get; set; }
        //public virtual DbSet<TRASPASO_POS_DET> TRASPASO_POS_DET { get; set; }
        //public virtual DbSet<TRIBUTO> TRIBUTO { get; set; }
        //public virtual DbSet<U_COD_AGRUPADOR> U_COD_AGRUPADOR { get; set; }
        //public virtual DbSet<U_PROCEDENCIA> U_PROCEDENCIA { get; set; }
        //public virtual DbSet<U_TDEPOSITO> U_TDEPOSITO { get; set; }
        //public virtual DbSet<U_UNIDAD_MILITAR> U_UNIDAD_MILITAR { get; set; }
        //public virtual DbSet<UBICACION> UBICACION { get; set; }
        //public virtual DbSet<UNIDAD> UNIDAD { get; set; }
        //public virtual DbSet<UNIDAD_DE_MEDIDA> UNIDAD_DE_MEDIDA { get; set; }
        //public virtual DbSet<UNIDAD_FRACCION> UNIDAD_FRACCION { get; set; }
        //public virtual DbSet<UNIDAD_MEDICION> UNIDAD_MEDICION { get; set; }
        //public virtual DbSet<UNIDAD_OPERATIVA> UNIDAD_OPERATIVA { get; set; }
        //public virtual DbSet<USUARIO_AJUSTE> USUARIO_AJUSTE { get; set; }
        //public virtual DbSet<USUARIO_BODEGA> USUARIO_BODEGA { get; set; }
        //public virtual DbSet<USUARIO_CAJA> USUARIO_CAJA { get; set; }
        //public virtual DbSet<USUARIO_CAJA_FA> USUARIO_CAJA_FA { get; set; }
        //public virtual DbSet<USUARIO_PAQUETE> USUARIO_PAQUETE { get; set; }
        //public virtual DbSet<USUARIO_PAQUETE_CR> USUARIO_PAQUETE_CR { get; set; }
        //public virtual DbSet<USUARIO_PRESUP> USUARIO_PRESUP { get; set; }
        //public virtual DbSet<USUARIOS_APROB_OC> USUARIOS_APROB_OC { get; set; }
        //public virtual DbSet<USUARIOS_DEPARTAMENTO> USUARIOS_DEPARTAMENTO { get; set; }
        //public virtual DbSet<USUARIOS_X_CENTRO> USUARIOS_X_CENTRO { get; set; }
        //public virtual DbSet<VACACION> VACACION { get; set; }
        //public virtual DbSet<VALE> VALE { get; set; }
        //public virtual DbSet<VALE_MOV_PRES> VALE_MOV_PRES { get; set; }
        //public virtual DbSet<VALOR_ADICIONAL_ME> VALOR_ADICIONAL_ME { get; set; }
        //public virtual DbSet<VENDEDOR> VENDEDOR { get; set; }
        //public virtual DbSet<VERSION_FLUJO_CAJA> VERSION_FLUJO_CAJA { get; set; }
        //public virtual DbSet<VERSION_NIVEL> VERSION_NIVEL { get; set; }
        //public virtual DbSet<VISTA_BI> VISTA_BI { get; set; }
        //public virtual DbSet<VISTAS_PIVOTE> VISTAS_PIVOTE { get; set; }
        //public virtual DbSet<ZONA> ZONA { get; set; }
        //public virtual DbSet<ADMIN_CONCEPTO> ADMIN_CONCEPTO { get; set; }
        //public virtual DbSet<AJUSTE_ACC_SALDO> AJUSTE_ACC_SALDO { get; set; }
        //public virtual DbSet<APROBACION_DETALLE> APROBACION_DETALLE { get; set; }
        //public virtual DbSet<ARTICULO_PADRE_HIJO> ARTICULO_PADRE_HIJO { get; set; }
        //public virtual DbSet<ARTICULO_PRECIO_TEMPORAL> ARTICULO_PRECIO_TEMPORAL { get; set; }
        //public virtual DbSet<AUDIT_AJUSTES_NOMI> AUDIT_AJUSTES_NOMI { get; set; }
        //public virtual DbSet<AUDITORIA_AD> AUDITORIA_AD { get; set; }
        //public virtual DbSet<AUDITORIA_DE_PROC> AUDITORIA_DE_PROC { get; set; }
        //public virtual DbSet<BITACORA> BITACORA { get; set; }
        //public virtual DbSet<CALCULO_AJUSTES_NOMI> CALCULO_AJUSTES_NOMI { get; set; }
        //public virtual DbSet<CARGA_CCCB_ERRORES> CARGA_CCCB_ERRORES { get; set; }
        //public virtual DbSet<CG_CERTIFICADO_RET> CG_CERTIFICADO_RET { get; set; }
        //public virtual DbSet<COD_OBSERVA_ISSS> COD_OBSERVA_ISSS { get; set; }
        //public virtual DbSet<COSTO_PRODUCCION_LOGIC> COSTO_PRODUCCION_LOGIC { get; set; }
        //public virtual DbSet<CS_SUMMARY_COLUMN> CS_SUMMARY_COLUMN { get; set; }
        //public virtual DbSet<CS_TBL_REPORTES> CS_TBL_REPORTES { get; set; }
        //public virtual DbSet<CUADRE_CONTA_AUX> CUADRE_CONTA_AUX { get; set; }
        //public virtual DbSet<EMPLEADO_CONC_NOMI_TEMP> EMPLEADO_CONC_NOMI_TEMP { get; set; }
        //public virtual DbSet<GLOBALES_AF> GLOBALES_AF { get; set; }
        //public virtual DbSet<GLOBALES_AM> GLOBALES_AM { get; set; }
        //public virtual DbSet<GLOBALES_AS> GLOBALES_AS { get; set; }
        //public virtual DbSet<GLOBALES_BI> GLOBALES_BI { get; set; }
        //public virtual DbSet<GLOBALES_CB> GLOBALES_CB { get; set; }
        //public virtual DbSet<GLOBALES_CC> GLOBALES_CC { get; set; }
        //public virtual DbSet<GLOBALES_CF> GLOBALES_CF { get; set; }
        //public virtual DbSet<GLOBALES_CG> GLOBALES_CG { get; set; }
        //public virtual DbSet<GLOBALES_CH> GLOBALES_CH { get; set; }
        //public virtual DbSet<GLOBALES_CI> GLOBALES_CI { get; set; }
        //public virtual DbSet<GLOBALES_CN> GLOBALES_CN { get; set; }
        //public virtual DbSet<GLOBALES_CO> GLOBALES_CO { get; set; }
        //public virtual DbSet<GLOBALES_CP> GLOBALES_CP { get; set; }
        //public virtual DbSet<GLOBALES_CR> GLOBALES_CR { get; set; }
        //public virtual DbSet<GLOBALES_CV> GLOBALES_CV { get; set; }
        //public virtual DbSet<GLOBALES_EV> GLOBALES_EV { get; set; }
        //public virtual DbSet<GLOBALES_FA> GLOBALES_FA { get; set; }
        //public virtual DbSet<GLOBALES_POS> GLOBALES_POS { get; set; }
        //public virtual DbSet<GLOBALES_PV> GLOBALES_PV { get; set; }
        //public virtual DbSet<GLOBALES_RH> GLOBALES_RH { get; set; }
        //public virtual DbSet<GLOBALES_SP> GLOBALES_SP { get; set; }
        //public virtual DbSet<HIST_CREDITO_EMP> HIST_CREDITO_EMP { get; set; }
        //public virtual DbSet<IMAGENES> IMAGENES { get; set; }
        //public virtual DbSet<INCONSISTENCIA_SINC_POS> INCONSISTENCIA_SINC_POS { get; set; }
        //public virtual DbSet<LIQUIDACION_PAGO_DET> LIQUIDACION_PAGO_DET { get; set; }
        //public virtual DbSet<PEDIDO_SOLICITUD_LINEA> PEDIDO_SOLICITUD_LINEA { get; set; }
        //public virtual DbSet<PRESUPUESTO_CI_CR> PRESUPUESTO_CI_CR { get; set; }
        //public virtual DbSet<REPORT_USER> REPORT_USER { get; set; }
        //public virtual DbSet<REPORTE_INVENTARIO_PERU> REPORTE_INVENTARIO_PERU { get; set; }
        //public virtual DbSet<SEGUIMIENTO_FACT> SEGUIMIENTO_FACT { get; set; }
        //public virtual DbSet<SEGUIMIENTO_ORDEN> SEGUIMIENTO_ORDEN { get; set; }
        //public virtual DbSet<SINCRONIZACION_ECRM> SINCRONIZACION_ECRM { get; set; }
        //public virtual DbSet<SP_ARTICULO> SP_ARTICULO { get; set; }
        //public virtual DbSet<SP_ARTICULO_PROVEEDOR> SP_ARTICULO_PROVEEDOR { get; set; }
        //public virtual DbSet<SP_AUDIT_TRANS_INV> SP_AUDIT_TRANS_INV { get; set; }
        //public virtual DbSet<SP_BODEGA> SP_BODEGA { get; set; }
        //public virtual DbSet<SP_DEPARTAMENTO> SP_DEPARTAMENTO { get; set; }
        //public virtual DbSet<SP_EMBARQUE> SP_EMBARQUE { get; set; }
        //public virtual DbSet<SP_EMBARQUE_LINEA> SP_EMBARQUE_LINEA { get; set; }
        //public virtual DbSet<SP_EXISTENCIA_BODEGA> SP_EXISTENCIA_BODEGA { get; set; }
        //public virtual DbSet<SP_FACTURA_LINEA> SP_FACTURA_LINEA { get; set; }
        //public virtual DbSet<SP_HISTORIAL> SP_HISTORIAL { get; set; }
        //public virtual DbSet<SP_ORDEN_COMPRA> SP_ORDEN_COMPRA { get; set; }
        //public virtual DbSet<SP_ORDEN_COMPRA_LINEA> SP_ORDEN_COMPRA_LINEA { get; set; }
        //public virtual DbSet<SP_PRECIO_ART_PROV> SP_PRECIO_ART_PROV { get; set; }
        //public virtual DbSet<SP_PROB_DETALLE> SP_PROB_DETALLE { get; set; }
        //public virtual DbSet<SP_PROBABILIDAD> SP_PROBABILIDAD { get; set; }
        //public virtual DbSet<SP_PROVEEDOR> SP_PROVEEDOR { get; set; }
        //public virtual DbSet<SP_TRANSACCION_INV> SP_TRANSACCION_INV { get; set; }
        //public virtual DbSet<TEMP_PRIMITIVA_HISTORICA> TEMP_PRIMITIVA_HISTORICA { get; set; }
        //public virtual DbSet<TRASLADO_IVA> TRASLADO_IVA { get; set; }
        //public virtual DbSet<TRASLADO_IVA_CTAS_IMPUESTOS> TRASLADO_IVA_CTAS_IMPUESTOS { get; set; }
        //public virtual DbSet<TRASLADO_IVA_CUENTAS> TRASLADO_IVA_CUENTAS { get; set; }
        //public virtual DbSet<TRASLADO_IVA_RETENCIONES> TRASLADO_IVA_RETENCIONES { get; set; }
        //public virtual DbSet<U_ACTIV_ECONOMICA> U_ACTIV_ECONOMICA { get; set; }
        //public virtual DbSet<U_ESQUEMA_FISCAL> U_ESQUEMA_FISCAL { get; set; }
        //public virtual DbSet<U_TIPO_DOCUMENTO> U_TIPO_DOCUMENTO { get; set; }
        //public virtual DbSet<USO_CFDI> USO_CFDI { get; set; }

        public virtual DbSet<FacturaTemporal> FacturaTemporal { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<RolesUsuarios> RolesUsuarios { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<FuncionesRoles> FuncionesRoles { get; set; }
        public virtual DbSet<Funciones> Funciones { get; set; }

        //vista
        public virtual DbSet<ViewArticulo> ViewArticulo { get; set; }

    }
}
